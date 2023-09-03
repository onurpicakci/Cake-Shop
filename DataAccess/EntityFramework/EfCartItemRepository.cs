using DataAccess.Context;
using DataAccess.Interface;
using DataAccess.Repository;
using Domain.Entity;

namespace DataAccess.EntityFramework;

public class EfCartItemRepository : CartItemRepository, ICartItemRepository
{
    public EfCartItemRepository(CakeShopDbContext context) : base(context)
    {
    }
}