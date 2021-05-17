using ArsAffiliate.Application.EfcApplications;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArsAffiliate.Authentication.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AccountApplication applicationAccount;

        public BaseController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, IMapper mapper)
        {
            applicationAccount = AccountApplication.GetInstance(userManager, signManager, mapper);
        }
    }
}
