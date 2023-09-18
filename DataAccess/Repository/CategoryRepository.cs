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

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }
}