using Domain.Entity;

namespace DataAccess.Interface;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
}