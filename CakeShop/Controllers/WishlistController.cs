using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class WishlistController : Controller
{
    private readonly IWishlistService _wishlistService;
    private readonly ICakeService _cakeService;

    public WishlistController(IWishlistService wishlistService, ICakeService cakeService)
    {
        _wishlistService = wishlistService;
        _cakeService = cakeService;
    }

    public IActionResult Index()
    {
        var wishlist = _wishlistService.GetAllWishlists().ToList();
        return View(wishlist);
    }

    public IActionResult AddToWishlist(int id)
    {
        var cake = _cakeService.GetAllCakes().FirstOrDefault(x => x.Id == id);
        if (cake != null)
        {
            _wishlistService.AddWishlist(cake);
        }

        return RedirectToAction("Index");
    }

    public IActionResult RemoveWishlist(int id)
    {
        var cake = _cakeService.GetAllCakes().FirstOrDefault(x => x.Id == id);
        if (cake != null)
        {
            _wishlistService.RemoveWishlist(cake);
        }

        return RedirectToAction("Index");
    }

    public IActionResult GetWishlistItems()
    {
        var total = _wishlistService.GetAllWishlists().Count();
        return Json(total);
    }
}