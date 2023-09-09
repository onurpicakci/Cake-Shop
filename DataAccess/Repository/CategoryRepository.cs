using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly CakeShopDbContext _context;

    public CategoryRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }
    
}