using Domain.Entity;

namespace CakeShop.ViewModels;

public class CheckoutViewModel
{
    public Order Order { get; set; } = default!;
    
    public List<CartItem> CartItems { get; set; } = default!;
    
    public decimal ShoppingCartTotal { get; set; }
}