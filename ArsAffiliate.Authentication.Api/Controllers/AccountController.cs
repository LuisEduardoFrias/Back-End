using ArsAffiliate.Domain.Dtos;
using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Authentication.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : BaseController
    {


        public AccountController(UserManager<User> userManager, SignInManager<User> signManager, IMapper mapper) :
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
