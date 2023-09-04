using Domain.Entity;

namespace Application.Interfaces;

public interface ICategoryService
{
    List<Category> GetAllCategories();

}