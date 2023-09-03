using Domain.Entity;

namespace DataAccess.Interface;

public interface ICakeRepository 
{
    void Insert(Cake entity);
    
    void Delete(Cake entity);
    
    void Update(Cake entity);
    
    IEnumerable<Cake> GetAllCakes();
    
    IEnumerable<Cake> CakeOfTheWeek();
    Cake? GetCakeById(int cakeId);
    IEnumerable<Cake> SearchCakes(string searchQuery);
}