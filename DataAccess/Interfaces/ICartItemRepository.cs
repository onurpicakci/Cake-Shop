using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ICartItemRepository
{
    void AddToCart(Cake cake);
    
    int RemoveFromCart(Cake cake);
    
    List<CartItem> GetShoppingCartItems();
    
    void ClearCart();
    
    decimal GetShoppingCartTotal();
    
    List<CartItem> ShoppingCartItems { get; set; }

    void ClearCartItem(int cakeId);
}