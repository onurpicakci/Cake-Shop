using DataAccess.Context;
using DataAccess.Interfaces;
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
        using var context = new CakeShopDbContext();
        context.Add(entity);
        context.SaveChanges();
    }

    public void Delete(Cake entity)
    {
        using var context = new CakeShopDbContext();
        context.Remove(entity);
        context.SaveChanges();
    }

    public void Update(Cake entity)
    {
        using var context = new CakeShopDbContext();
        context.Update(entity);
        context.SaveChanges();
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

    public IEnumerable<Cake> GetCakesByCategoryName(string categoryName)
    {
        return _context.Cakes.Include(c => c.Category).Where(c => c.Category.Name == categoryName).ToList();
    }

    public IEnumerable<Cake> GetRelatedCakes(int cakeId)
    {
        var cake = _context.Cakes.Include(c => c.Category).FirstOrDefault(c => c.Id == cakeId);
        if (cake == null)
            return new List<Cake>();

        return _context.Cakes.Include(c => c.Category).Where(c => c.CategoryId == cake.CategoryId && c.Id != cakeId)
            .ToList();
    }
}