using Application.Interfaces;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class ShoppingCartController : Controller
{
    private readonly ICakeService _cakeService;
    private readonly ICartItemService _cartItemService;

    public ShoppingCartController(ICakeService cakeService, ICartItemService cartItemService)
    {
        _cakeService = cakeService;
        _cartItemService = cartItemService;
    }

    public ViewResult Index()
    {
        var items = _cartItemService.GetShoppingCartItems();
        _cartItemService.ShoppingCartItems = items;

        var shoppingCartViewModel =
            new ShoppingCartViewModel(_cartItemService, _cartItemService.GetShoppingCartTotal());
        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int cakeId)
    {
        var selectedCake = _cakeService.GetAllCakes().FirstOrDefault(x => x.Id == cakeId);

        if (selectedCake != null)
        {
            _cartItemService.AddToCart(selectedCake);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int cakeId)
    {
        var selectedCake = _cakeService.GetAllCakes().FirstOrDefault(x => x.Id == cakeId);

        if (selectedCake != null)
        {
            _cartItemService.RemoveFromCart(selectedCake);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult ClearCart()
    {
        _cartItemService.ClearCart();
        return RedirectToAction("Index");
    }

    public RedirectToActionResult ClearCartItem(int cakeId)
    {
        _cartItemService.ClearCartItem(cakeId);
        return RedirectToAction("Index");
    }
}