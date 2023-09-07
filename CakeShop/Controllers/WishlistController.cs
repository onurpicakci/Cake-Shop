using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class WishlistController : Controller
    {
        private readonly WishlistService _wishlistService;
        private readonly ICakeService _cakeService;

        public WishlistController(WishlistService wishlistService, ICakeService cakeService)
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
    }
}