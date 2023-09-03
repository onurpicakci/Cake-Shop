using DataAccess.Context;
using DataAccess.Interface;
using DataAccess.Repository;
using Domain.Entity;

namespace DataAccess.EntityFramework;

public class EfOrderRepository : OrderRepository, IOrderRepository
{
    public EfOrderRepository(CakeShopDbContext context, ICartItemRepository cartItemRepository) : base(context, cartItemRepository)
    {
    }
}