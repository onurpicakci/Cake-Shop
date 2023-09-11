using Domain.Entity;

namespace DataAccess.Interfaces;

public interface IOrderRepository
{
    void CreateOrder(Order order);
    Order GetOrderById(int id);
}