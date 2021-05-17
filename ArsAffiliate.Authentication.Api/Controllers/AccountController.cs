using ArsAffiliate.Domain.Dtos;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArsAffiliate.Authentication.Api.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : BaseController
    {


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, IMapper mapper) :
            base(userManager, signManager, mapper)
        {
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.createuser+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> CreateUser([FromBody] CreateUserDto CreateUserDto)
        {
            return await applicationAccount.CreateUserAsync(CreateUserDto);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.loign+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> Login([FromBody] LogerDto login)
        {
            return await applicationAccount.LoginAsync(login);
        }

    }
}
