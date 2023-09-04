using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfCakeRepository : CakeRepository, ICakeRepository
{
    public EfCakeRepository(CakeShopDbContext context) : base(context)
    {
    }
}