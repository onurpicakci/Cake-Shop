using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly CakeShopDbContext _context;
    private readonly ICartItemRepository _cartItemRepository;

    public OrderRepository(CakeShopDbContext context, ICartItemRepository cartItemRepository)
    {
        _context = context;
        _cartItemRepository = cartItemRepository;
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        List<CartItem> shoppingCartItems = _cartItemRepository.GetShoppingCartItems();
        order.OrderTotal = _cartItemRepository.GetShoppingCartTotal();
        order.OrderDetails = new List<OrderDetail>();

        foreach (CartItem? cartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = cartItem.Amount,
                CakeId = cartItem.Cake.Id,
                Price = cartItem.Cake.Price
            };
            order.OrderDetails.Add(orderDetail);
        }
        _context.Orders.Add(order);
        
        _context.SaveChanges();
    }
}