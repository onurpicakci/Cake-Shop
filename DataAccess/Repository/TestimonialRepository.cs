using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly CakeShopDbContext _context;

    public TestimonialRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public List<Testimonial> GetAllTestimonials()
    {
        return _context.Testimonials.ToList();
    }
}