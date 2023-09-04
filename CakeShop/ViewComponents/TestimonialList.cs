using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.ViewComponents;

public class TestimonialList : ViewComponent
{
    private readonly ITestimonialService _testimonialService;
    
    public TestimonialList(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }
    
    public IViewComponentResult Invoke()
    {
        var testimonials = _testimonialService.GetAllTestimonials();
        return View(testimonials);
    }
}