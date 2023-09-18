using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
    
    void AddCategory(Category category);
    
    void UpdateCategory(Category category);
    
    void DeleteCategory(int id);
    
    Category GetCategoryById(int id);
}