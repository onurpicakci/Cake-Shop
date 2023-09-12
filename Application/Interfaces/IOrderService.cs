using Domain.Entity;

namespace Application.Interfaces;

public interface IOrderService
{
    void CreateOrder(Order order);
    
    Order GetOrderById(int id);
    
    int GetLastOrderId();
}