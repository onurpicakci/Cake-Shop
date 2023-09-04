using Domain.Entity;

namespace Application.Interfaces;

public interface IAboutService
{
    List<About> GetAllAbouts();
}