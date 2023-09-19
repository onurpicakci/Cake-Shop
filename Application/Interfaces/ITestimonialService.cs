using Domain.Entity;

namespace Application.Interfaces;

public interface ITestimonialService
{
    List<Testimonial> GetAllTestimonials();
    
    void AddTestimonial(Testimonial testimonial);
    
    void UpdateTestimonial(Testimonial testimonial);
    
    void DeleteTestimonial(int id);
}