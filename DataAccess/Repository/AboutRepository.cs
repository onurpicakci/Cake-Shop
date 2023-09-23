using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class AboutRepository : IAboutRepository
{
    private readonly CakeShopDbContext _context;

    public AboutRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public List<About> GetAllAbouts()
    {
        return _context.Abouts.ToList();
    }

    public void UpdateAbout(About about)
    {
        _context.Abouts.Update(about);
        _context.SaveChanges();
    }
}