using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class CategoryRepository : ICategoryRepository
{
    public List<Category> GetAllCategories()
    {
        using var c = new CakeShopDbContext();
        return c.Categories.ToList();
    }
}