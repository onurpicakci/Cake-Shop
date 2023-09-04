using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class CakeService : ICakeService
{
    private readonly ICakeRepository _cakeRepository;

    public CakeService(ICakeRepository cakeRepository)
    {
        _cakeRepository = cakeRepository;
    }

    public void Insert(Cake entity)
    {
        _cakeRepository.Insert(entity);
    }

    public void Delete(Cake entity)
    {
        _cakeRepository.Delete(entity);
    }

    public void Update(Cake entity)
    {
        _cakeRepository.Update(entity);
    }

    public IEnumerable<Cake> GetAllCakes()
    {
        return _cakeRepository.GetAllCakes();
    }

    public IEnumerable<Cake> CakeOfTheWeek()
    {
        return _cakeRepository.CakeOfTheWeek();
    }

    public Cake? GetCakeById(int cakeId)
    {
        return _cakeRepository.GetCakeById(cakeId);
    }

    public IEnumerable<Cake> SearchCakes(string searchQuery)
    {
        return _cakeRepository.SearchCakes(searchQuery);
    }
}