using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ICakeRepository 
{
    void Insert(Cake entity);
    
    void Delete(Cake entity);
    
    void Update(Cake entity);
    
    IEnumerable<Cake> GetAllCakes();
    
    IEnumerable<Cake> CakeOfTheWeek();
    Cake? GetCakeById(int cakeId);
    IEnumerable<Cake> SearchCakes(string searchQuery);
    
    IEnumerable<Cake> GetCakesByCategoryName(string categoryName);
}