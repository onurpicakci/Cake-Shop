using Domain.Entity;

namespace Application.Interfaces;

public interface ITestimonialService
{
    List<Testimonial> GetAllTestimonials();
}