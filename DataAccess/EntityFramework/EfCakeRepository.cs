using DataAccess.Context;
using DataAccess.Interface;
using DataAccess.Repository;
using Domain.Entity;

namespace DataAccess.EntityFramework;

public class EfCakeRepository : CakeRepository, ICakeRepository
{
    public EfCakeRepository(CakeShopDbContext context) : base(context)
    {
    }
}