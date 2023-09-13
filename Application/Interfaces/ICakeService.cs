using Domain.Entity;

namespace Application.Interfaces;

public interface ICakeService
{
    void Insert(Cake entity);
    void Delete(Cake entity);
    void Update(Cake entity);
    IEnumerable<Cake> GetAllCakes();
    IEnumerable<Cake> CakeOfTheWeek();
    Cake? GetCakeById(int cakeId);
    IEnumerable<Cake> SearchCakes(string searchQuery);
    IEnumerable<Cake> GetCakesByCategoryName(string categoryName);
    
    IEnumerable<Cake> GetRelatedCakes(int cakeId);
}