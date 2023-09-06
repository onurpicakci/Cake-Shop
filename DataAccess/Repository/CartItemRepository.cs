using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repository;

public class CartItemRepository : ICartItemRepository
{
    private readonly CakeShopDbContext _context;
 
    public List<CartItem> ShoppingCartItems { get; set; } = default!;
    
    public string? ShoppingCartId { get; set; }
    
    public CartItemRepository(CakeShopDbContext context)
    {
        _context = context;
    }
    
    public static CartItemRepository GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        CakeShopDbContext context = services.GetService<CakeShopDbContext>() ?? throw new Exception("Error initializing");

        string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        session?.SetString("CartId", cartId);

        return new CartItemRepository(context) { ShoppingCartId = cartId };
    }

    public void AddToCart(Cake cake)
    {
        var shoppingCartItem = _context.CartItems.SingleOrDefault(
            x=> x.Cake.Id == cake.Id && x.ShoppingCartId == ShoppingCartId);
        
        if (shoppingCartItem == null)
        {
            shoppingCartItem = new CartItem
            {
                ShoppingCartId = ShoppingCartId,
                Cake = cake,
                Amount = 1
            };
            _context.CartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }

    public int RemoveFromCart(Cake cake)
    {
        var shoppingCartItem = _context.CartItems.SingleOrDefault(
            x=> x.Cake.Id == cake.Id && x.ShoppingCartId == ShoppingCartId);
        
        var localAmount = 0;
        
        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _context.CartItems.Remove(shoppingCartItem);
            }
        }
        _context.SaveChanges();
        return localAmount;
    }

    public List<CartItem> GetShoppingCartItems()
    {
        return _context.CartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
            .Include(x => x.Cake)
            .ToList();
    }

    public void ClearCart()
    {
        var cartItems = _context.CartItems.Where(x => x.ShoppingCartId == ShoppingCartId);
        _context.CartItems.RemoveRange(cartItems);
        _context.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = _context.CartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
            .Select(x => x.Cake.Price * x.Amount).Sum();

        return total;
    }
    
    public void ClearCartItem(int cakeId)
    {
        var cartItem = _context.CartItems.FirstOrDefault(x => x.Cake.Id == cakeId && x.ShoppingCartId == ShoppingCartId);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
    }
}