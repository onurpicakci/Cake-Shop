using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.CreateOrder(order);
    }

    public Order GetOrderById(int id)
    {
        return _orderRepository.GetOrderById(id);
    }
    
    public int GetLastOrderId()
    {
        return _orderRepository.GetLastOrderId();
    }
}