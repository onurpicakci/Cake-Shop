using Domain.Entity;

namespace DataAccess.Interfaces;

public interface IAboutRepository
{
    List<About> GetAllAbouts();
    void UpdateAbout(About about);
}