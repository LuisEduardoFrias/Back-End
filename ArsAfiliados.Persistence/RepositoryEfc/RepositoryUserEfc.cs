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
using ArsAfiliados.Domain.Entitys;
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


        public async Task<RequestAuthentication> CreateUser(CreateUserDto userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Name + userCredentials.LastName, Email = userCredentials.Email };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);

            if (result.Succeeded)
            {
                return await ConstrairToken(userCredentials, userCredentials.Name);
            }
            else
            {
                string _error = "";

                foreach (var error in result.Errors)
                {
                    _error = $"{error.Code} {error.Description}";
                }

                return new RequestAuthentication { Error = _error };
            }

        }


        public async Task<RequestAuthentication> Login(LogerDto userCredentials, string UserName)
        {
            var respons = await _signManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (respons.Succeeded)
            {
                return await ConstrairToken(userCredentials, UserName);
            }
            else
            {
                return new RequestAuthentication { Error = "Usuario o contraseña incorrecta" };
            }
        }


        private async Task<RequestAuthentication> ConstrairToken(LogerDto userCredentials, string UserName)
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

            return new RequestAuthentication()
            {
                UserName = UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
