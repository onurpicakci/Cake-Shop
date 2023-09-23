using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public IActionResult Index()
    {
        var about = _aboutService.GetAllAbouts().ToList();
        return View(about);
    }
}