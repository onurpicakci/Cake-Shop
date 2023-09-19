using Domain.Entity;

namespace DataAccess.Interfaces;

public interface IOrderRepository
{
    void CreateOrder(Order order);
    Order GetOrderById(int id);
    int GetLastOrderId();
    List<Order> GetLast30DayOrders();
    List<Order> GetAllOrders();
}