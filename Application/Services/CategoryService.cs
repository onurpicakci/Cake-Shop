using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public List<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }

    public void AddCategory(Category category)
    {
        _categoryRepository.AddCategory(category);
    }

    public void UpdateCategory(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
    }

    public Category GetCategoryById(int id)
    {
        return _categoryRepository.GetCategoryById(id);
    }
}