using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
}