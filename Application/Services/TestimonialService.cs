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
}