using DataAccess.Context;
using DataAccess.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CakeRepository : ICakeRepository
{
    private readonly CakeShopDbContext _context;

    public CakeRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public void Insert(Cake entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Cake entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(Cake entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Cake> GetAllCakes()
    {
        return _context.Cakes.Include(c => c.Category).ToList();
    }

    public IEnumerable<Cake> CakeOfTheWeek()
    {
        return _context.Cakes.Include(c => c.Category).Where(c => c.IsCakeOfTheWeek).ToList();
    }

    public Cake? GetCakeById(int cakeId)
    {
        return _context.Cakes.Include(c => c.Category).FirstOrDefault(c => c.Id == cakeId);
    }

    public IEnumerable<Cake> SearchCakes(string searchQuery)
    {
        if (string.IsNullOrEmpty(searchQuery))
            return _context.Cakes.Include(c => c.Category);

        return _context.Cakes.Include(c => c.Category).Where(c =>
            c.Name.ToLower().Contains(searchQuery.ToLower()) ||
            c.LongDescription.ToLower().Contains(searchQuery.ToLower()));
    }
}