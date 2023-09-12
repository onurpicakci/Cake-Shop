using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfCouponRepository : CouponRepository, ICouponRepository
{
    public EfCouponRepository(CakeShopDbContext context) : base(context)
    {
    }
}