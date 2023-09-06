using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    
    public CartItemService(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }
    
    public void AddToCart(Cake cake)
    {
        _cartItemRepository.AddToCart(cake);
    }

    public int RemoveFromCart(Cake cake)
    {
       return _cartItemRepository.RemoveFromCart(cake);
    }

    public List<CartItem> GetShoppingCartItems()
    {
        return _cartItemRepository.GetShoppingCartItems();
    }

    public void ClearCart()
    {
        _cartItemRepository.ClearCart();
    }

    public decimal GetShoppingCartTotal()
    {
        return _cartItemRepository.GetShoppingCartTotal();
    }
    
    public void ClearCartItem(int cakeId)
    {
        _cartItemRepository.ClearCartItem(cakeId);
    }

    public List<CartItem> ShoppingCartItems { get; set; }
}