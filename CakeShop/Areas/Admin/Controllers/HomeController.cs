using System.Xml.Linq;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
[Authorize]
public class HomeController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICakeService _cakeService;
    private readonly ICategoryService _categoryService;
    private readonly IOrderService _orderService;
    private readonly IWishlistService _wishlistService;

    public HomeController(UserManager<IdentityUser> userManager, ICakeService cakeService, ICategoryService categoryService, IOrderService orderService, IWishlistService wishlistService)
    {
        _userManager = userManager;
        _cakeService = cakeService;
        _categoryService = categoryService;
        _orderService = orderService;
        _wishlistService = wishlistService;
    }
    
    public IActionResult Index()
    {
        var user = _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.UserName = user.Result.UserName;
        
        string api = "503406f4fc625d91168b358a17238c92";
        string connection = "https://api.openweathermap.org/data/2.5/weather?q=bursa&mode=xml&lang=tr&units=metric&appid=" + api;
        XDocument document = XDocument.Load(connection);
        ViewBag.weather = document.Descendants("temperature").FirstOrDefault()?.Attribute("value").Value;

        ViewBag.v1 = _cakeService.GetAllCakes().Count();
        ViewBag.v2 = _categoryService.GetAllCategories().Count();
        ViewBag.v3 = _orderService.GetLast30DayOrders().Count();
        ViewBag.v4 = _wishlistService.GetAllWishlists().Count();
        return View();
    }
}