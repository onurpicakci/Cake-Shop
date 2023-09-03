using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        
        public OrderController(IOrderRepository orderRepository, ICartItemRepository cartItemRepository)
        {
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
        }
        
        public IActionResult Checkout()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _cartItemRepository.GetShoppingCartItems();
            _cartItemRepository.ShoppingCartItems = items;

            if(_cartItemRepository.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is emtpy, add some pies first");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _cartItemRepository.ClearCart();
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