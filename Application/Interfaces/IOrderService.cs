using Domain.Entity;

namespace Application.Interfaces;

public interface IOrderService
{
    void CreateOrder(Order order);
}