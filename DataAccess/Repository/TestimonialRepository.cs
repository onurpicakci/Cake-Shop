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

    public void AddTestimonial(Testimonial testimonial)
    {
        var context = new CakeShopDbContext();
        context.Testimonials.Add(testimonial);
        context.SaveChanges();
    }

    public void UpdateTestimonial(Testimonial testimonial)
    {
        var context = new CakeShopDbContext();
        context.Testimonials.Update(testimonial);
        context.SaveChanges();
    }

    public void DeleteTestimonial(int id)
    {
        var testimonial = _context.Testimonials.Find(id);
        if (testimonial != null)
        {
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
        }
    }
}