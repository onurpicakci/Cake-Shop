using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace CakeShop.ViewModels;

public class ShoppingCartViewModel
{
    public ShoppingCartViewModel(ICartItemService cartItemService, decimal shoppingCartTotal)
    {
        ShoppingCart = cartItemService;
        ShoppingCartTotal = shoppingCartTotal;
    }
    
    public ICartItemService ShoppingCart { get; }
    public decimal ShoppingCartTotal { get; }
}