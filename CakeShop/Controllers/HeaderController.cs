using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class HeaderController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public HeaderController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        public IActionResult GetCartTotal()
        {
            var total = _cartItemService.GetShoppingCartTotal();
            return Json(total);
        }
        
        public IActionResult GetCartItems()
        {
            var items = _cartItemService.GetShoppingCartItems().Count;
            return Json(items);
        }
    }
}