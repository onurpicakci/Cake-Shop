using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ITestimonialRepository
{
    List<Testimonial> GetAllTestimonials();
}