using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

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

    public Order GetOrderById(int id)
    {
        return _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Cake)
            .FirstOrDefault(o => o.Id == id);
    }

    public int GetLastOrderId()
    {
        return _context.Orders.OrderByDescending(x => x.OrderPlaced).FirstOrDefault().Id;
    }

    public List<Order> GetLast30DayOrders()
    {
        return _context.Orders.Where(x => x.OrderPlaced >= DateTime.Now.AddDays(-30)).ToList();
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Cake)
            .OrderByDescending(o => o.OrderPlaced)
            .ToList();
    }
}