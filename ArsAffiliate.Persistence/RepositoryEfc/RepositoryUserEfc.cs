using ArsAffiliate.Domain.Dtos;
using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Service.SettingsStrings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryUserEfc
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        

        public static RepositoryUserEfc GetInstance(UserManager<User> userManager, SignInManager<User> signManager) =>
            new RepositoryUserEfc(userManager, signManager);


        private RepositoryUserEfc(UserManager<User> userManager, SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }


        public async Task<RequestAuthentication> CreateUserAsync(CreateUserDto userCredentials)
        {
            var user = new User { FirstName = userCredentials.Name , LastName = userCredentials.LastName, Email = userCredentials.Email, UserName = userCredentials.Email };

            IdentityResult result = new IdentityResult();

            try
            {
                result = await _userManager.CreateAsync(user, userCredentials.Password);
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }

            if (result.Succeeded)
            {
                return await ConstrairToken(userCredentials.Email);
            }
            else
            {
                string error = "";
                foreach (var error_ in result.Errors)
                {
                    error = $"{error_.Code} - {error_.Description}";
                }

                return new RequestAuthentication 
                { Error = error };
            }
        }


        public async Task<RequestAuthentication> LoginAsync(LogerDto userCredentials)
        {
            try
            {
                var respons = await _signManager.CheckPasswordSignInAsync(
                    await _userManager.FindByEmailAsync(userCredentials.Email),
                    userCredentials.Password, false);

                if (respons.Succeeded)
                {
                    return await ConstrairToken(userCredentials.Email);
                }
                else
                {
                    return new RequestAuthentication { Error = "Usuario o contraseña incorrecta" };
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        private async Task<RequestAuthentication> ConstrairToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claimsdb = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var Roles = await _userManager.GetRolesAsync(user);

            foreach(string role in Roles)
            {
                claims.Add( new Claim(ClaimTypes.Role, role));
            }

            claims.AddRange(claimsdb);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingsStrings.KeyJwt));
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
                UserName = user.FirstName,
                UserId = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
