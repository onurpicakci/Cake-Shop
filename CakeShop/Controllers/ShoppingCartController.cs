using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using CakeShop.Models;
using CakeShop.ViewModels;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICakeService? _cakeService;
        private readonly ICartItemService _cartItemService;

        public ShoppingCartController(ICakeService cakeService, ICartItemService cartItemService)
        {
            _cakeService = _cakeService;
            _cartItemService = cartItemService;
        }

        public ViewResult Index()
        {
            var items = _cartItemService.GetShoppingCartItems();
            _cartItemService.ShoppingCartItems = items;
            
            var shoppingCartViewModel = new ShoppingCartViewModel(_cartItemService, _cartItemService.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
        
        public RedirectToActionResult AddToShoppingCart(int cakeId)
        {
            var selectedCake = _cakeService?.GetAllCakes().FirstOrDefault(x => x.Id == cakeId);

            if (selectedCake != null)
            {
                _cartItemService.AddToCart(selectedCake);
            }
            return RedirectToAction("Index");
        }
        
        public RedirectToActionResult RemoveFromShoppingCart(int cakeId)
        {
            var selectedCake = _cakeService?.GetCakeById(cakeId);

            if (selectedCake != null)
            {
                _cartItemService.RemoveFromCart(selectedCake);
            }
            return RedirectToAction("Index");
        }
    }
}