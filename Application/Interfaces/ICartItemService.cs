using Domain.Entity;

namespace Application.Interfaces;

public interface ICartItemService
{
    void AddToCart(Cake cake);
    
    int RemoveFromCart(Cake cake);
    
    List<CartItem> GetShoppingCartItems();
    
    void ClearCart();
    
    decimal GetShoppingCartTotal();
    
    List<CartItem> ShoppingCartItems { get; set; }
    
    void ClearCartItem(int cakeId);
}