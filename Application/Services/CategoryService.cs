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
}