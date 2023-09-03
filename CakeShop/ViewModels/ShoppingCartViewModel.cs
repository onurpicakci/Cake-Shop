using DataAccess.Interface;
using Domain.Entity;

namespace CakeShop.ViewModels;

public class ShoppingCartViewModel
{
    public ShoppingCartViewModel(ICartItemRepository cartItemRepository, decimal shoppingCartTotal)
    {
        ShoppingCart = cartItemRepository;
        ShoppingCartTotal = shoppingCartTotal;
    }
    
    public ICartItemRepository ShoppingCart { get; }
    public decimal ShoppingCartTotal { get; }
}