using ArsAffiliate.Application.EfcApplications;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArsAffiliate.Api.Authentication.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AccountApplication applicationAccount;

        public BaseController(UserManager<User> userManager, SignInManager<User> signManager, IMapper mapper)
        {
            applicationAccount = AccountApplication.GetInstance(userManager, signManager, mapper);
        }
    }
}
