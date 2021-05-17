using ArsAffiliate.Domain.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ArsAffiliate.Application.EfcApplications
{
    public class AccountApplication : BaseApplicationController
    {
        #region Singletom

        public static AccountApplication Instantice { get; set; }

        public static AccountApplication GetInstance(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new AccountApplication(userManager, signManager, mapper);

            return Instantice;
        }

        #endregion

        private AccountApplication(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, IMapper mapper) :
            base(userManager, signManager, mapper)
        {
        }

        public async Task<RequestAuthenticationDto> CreateUserAsync(CreateUserDto CreateUserDto)
        {
            var request = await AccountEfc.CreateUserAsync(CreateUserDto);

            if (request.Error != null)
                throw new HttpResponseException { MensajeError = request.Error, StatusCode = System.Net.HttpStatusCode.BadRequest };

            return mapper.Map<RequestAuthenticationDto>(request);
        }

        public async Task<RequestAuthenticationDto> LoginAsync(LogerDto login)
        {
            //user = _UserManager.GetUserAsync((ClaimsPrincipal)this.User.Identity);

            var request = await AccountEfc.LoginAsync(login, "");

            if (request.Error != null)
                throw new HttpResponseException { MensajeError = request.Error, StatusCode = System.Net.HttpStatusCode.BadRequest };

            return mapper.Map<RequestAuthenticationDto>(request);
        }
    }
}
