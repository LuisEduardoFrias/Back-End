using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Persistence.RepositoryEfc;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using System.Security.Claims;
//

namespace ArsAfiliados.Authentication.Api.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignManager;
        private readonly IMapper _Mapper;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, IMapper mapper)
        {
            _UserManager = userManager;
            _SignManager = signManager;
            _Mapper = mapper;
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.createuser+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> CreateUser([FromBody] CreateUserDto CreateUserDto)
        {
            var request = await RepositoryUserEfc.GetInstance(_UserManager, _SignManager).CreateUser(CreateUserDto);

            if (request.Error != null)
                return BadRequest(request.Error);

            return _Mapper.Map<RequestAuthenticationDto>(request);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.loign+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> Login([FromBody] LogerDto login)
        {
            var user = _UserManager.GetUserAsync((ClaimsPrincipal)this.User.Identity);

            var request = await RepositoryUserEfc.GetInstance(_UserManager, _SignManager).Login(login, "" );

            if (request.Error != null)
                return BadRequest(request.Error);

            return _Mapper.Map<RequestAuthenticationDto>(request);
        }

    }
}
