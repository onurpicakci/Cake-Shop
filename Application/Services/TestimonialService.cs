using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class TestimonialService : ITestimonialService
{
    private readonly ITestimonialRepository _testimonialRepository;

    public TestimonialService(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public List<Testimonial> GetAllTestimonials()
    {
        return _testimonialRepository.GetAllTestimonials();
    }

    public void AddTestimonial(Testimonial testimonial)
    {
        _testimonialRepository.AddTestimonial(testimonial);
    }

    public void UpdateTestimonial(Testimonial testimonial)
    {
        _testimonialRepository.UpdateTestimonial(testimonial);
    }

    public void DeleteTestimonial(int id)
    {
        _testimonialRepository.DeleteTestimonial(id);
    }
}