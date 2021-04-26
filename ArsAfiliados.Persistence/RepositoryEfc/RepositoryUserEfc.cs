using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Service.SettingsStrings;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryUserEfc
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;


        public static RepositoryUserEfc GetInstance(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager) =>
            new RepositoryUserEfc(userManager, signManager);


        private RepositoryUserEfc(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }


        public async Task<RequestAuthenticationDto> CreateUser(UserCredentialsDto userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Email, Email = userCredentials.Email };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);

            if (result.Succeeded)
            {
                return await ConstrairToken(userCredentials);
            }
            else
            {
                string _error = "";

                foreach (var error in result.Errors)
                {
                    _error = $"{error.Code} {error.Description}";
                }

                return new RequestAuthenticationDto { Error = _error };
            }

        }

        public async Task<RequestAuthenticationDto> Login(UserCredentialsDto userCredentials)
        {
            var respons = await _signManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (respons.Succeeded)
            {
                return await ConstrairToken(userCredentials);
            }
            else
            {
                return new RequestAuthenticationDto { Error = "Usuario o contraseña incorrecta" };
            }
        }


        private async Task<RequestAuthenticationDto> ConstrairToken(UserCredentialsDto userCredentials)
        {
            var claims = new List<Claim>
            {
                new Claim("email",userCredentials.Email)
            };

            var usuario = await _userManager.FindByEmailAsync(userCredentials.Email);
            var claimsdb = await _userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsdb);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingsStrings.Getinstance().KeyJwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(9);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new RequestAuthenticationDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
