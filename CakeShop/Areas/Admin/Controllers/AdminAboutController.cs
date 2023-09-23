using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/About/[action]")]
public class AdminAboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AdminAboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public IActionResult Index()
    {
        var abouts = _aboutService.GetAllAbouts();
        return View(abouts);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult UpdateAbout(int id)
    {
        var about = _aboutService.GetAllAbouts().FirstOrDefault(a => a.Id == id);
        return View(about);
    }

    [HttpPost]
    [Route("{id:int}")]
    public IActionResult UpdateAbout(About about)
    {
        _aboutService.UpdateAbout(about);
        return RedirectToAction("Index");
    }
}