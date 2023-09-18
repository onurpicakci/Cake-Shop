using Domain.Entity;

namespace Application.Interfaces;

public interface ICategoryService
{
    List<Category> GetAllCategories();
    
    void AddCategory(Category category);
    
    void UpdateCategory(Category category);
    
    void DeleteCategory(int id);
    
    Category GetCategoryById(int id);
}