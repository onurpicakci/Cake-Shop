using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Models;
using CakeShop.ViewModels;
using DataAccess.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public ShoppingCartController(ICakeRepository cakeRepository, ICartItemRepository cartItemRepository)
        {
            _cakeRepository = cakeRepository;
            _cartItemRepository = cartItemRepository;
        }

        public ViewResult Index()
        {
            var items = _cartItemRepository.GetShoppingCartItems();
            _cartItemRepository.ShoppingCartItems = items;
            
            var shoppingCartViewModel = new ShoppingCartViewModel(_cartItemRepository, _cartItemRepository.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
        
        public RedirectToActionResult AddToShoppingCart(int cakeId)
        {
            var selectedCake = _cakeRepository.GetAllCakes().FirstOrDefault(x => x.Id == cakeId);

            if (selectedCake != null)
            {
                _cartItemRepository.AddToCart(selectedCake);
            }
            return RedirectToAction("Index");
        }
        
        public RedirectToActionResult RemoveFromShoppingCart(int cakeId)
        {
            var selectedCake = _cakeRepository.GetCakeById(cakeId);

            if (selectedCake != null)
            {
                _cartItemRepository.RemoveFromCart(selectedCake);
            }
            return RedirectToAction("Index");
        }
    }
}