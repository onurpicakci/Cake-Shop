using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("Identity/[controller]/[action]")]
    [AllowAnonymous]
    public class LogoutController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public LogoutController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login", new { area = "Identity" });
        }
    }
}