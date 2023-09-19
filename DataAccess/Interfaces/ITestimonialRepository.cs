using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ITestimonialRepository
{
    List<Testimonial> GetAllTestimonials();
    
    void AddTestimonial(Testimonial testimonial);
    
    void UpdateTestimonial(Testimonial testimonial);
    
    void DeleteTestimonial(int id);
}