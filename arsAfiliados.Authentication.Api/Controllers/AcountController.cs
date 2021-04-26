using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Persistence.RepositoryEfc;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
//

namespace ArsAfiliados.Authentication.Api.Controllers
{

    [Route("api/acount")]
    [ApiController]
    public class AcountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AcountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaf.createuser+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> CreateUser([FromBody] UserCredentialsDto userCredentials)
        {
            var request = await RepositoryUserEfc.GetInstance(_userManager, _signManager).CreateUser(userCredentials);

            if (request.Error != null)
                return BadRequest(request.Error);

            return request;
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaf.loign+json" })]
        public async Task<ActionResult<RequestAuthenticationDto>> Login([FromBody] UserCredentialsDto userCredentials)
        {
            var request = await RepositoryUserEfc.GetInstance(_userManager, _signManager).Login(userCredentials);

            if (request.Error != null)
                return BadRequest(request.Error);

            return request;
        }

    }
}
