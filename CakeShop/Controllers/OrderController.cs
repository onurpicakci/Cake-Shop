using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;
        
        public OrderController(IOrderService orderService, ICartItemService cartItemService)
        {
            _orderService = orderService;
            _cartItemService = cartItemService;
        }
        
        public IActionResult Checkout()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _cartItemService.GetShoppingCartItems();
            _cartItemService.ShoppingCartItems = items;

            if(_cartItemService.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is emtpy, add some pies first");
            }
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _cartItemService.ClearCart();
                return RedirectToAction("");
            }
            return View(order);
        }
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for you order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}