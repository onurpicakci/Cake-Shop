using Domain.Entity;

namespace DataAccess.Interface;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}