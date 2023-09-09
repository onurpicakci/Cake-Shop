using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Domain.Entity;

namespace DataAccess.EntityFramework;

public class EfCategoryRepository : CategoryRepository, ICategoryRepository
{
    public EfCategoryRepository(CakeShopDbContext context) : base(context)
    {
    }
}