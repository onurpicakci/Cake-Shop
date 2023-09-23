using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class CakeController : Controller
{
    private readonly ICakeService _cakeService;
    
    public CakeController(ICakeService cakeService)
    {
        _cakeService = cakeService;
    }

    public IActionResult Index()
    {
        var values = _cakeService.GetAllCakes().ToList();
        return View(values);
    }

    public ViewResult Shop()
    {
        var cakes = _cakeService.GetAllCakes().ToList();
        return View(cakes);
    }

    public IActionResult Details(int id)
    {
        var cake = _cakeService.GetCakeById(id);
        if (cake == null)
            return NotFound();

        return View(cake);
    }
}