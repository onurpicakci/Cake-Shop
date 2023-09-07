using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("Identity/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.PhoneNumber = user.PhoneNumber;
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PhoneNumber = model.PhoneNumber;
                
                var result = await _userManager.UpdateAsync(user);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Cake");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}