using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Testimonial/[action]")]
public class AdminTestimonialController : Controller
{
    private readonly ITestimonialService _testimonialService;

    public AdminTestimonialController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var testimonials = _testimonialService.GetAllTestimonials();
        return View(testimonials);
    }

    [HttpGet]
    public IActionResult AddTestimonial()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddTestimonial(Testimonial testimonial, IFormFile? imageFile)
    {
        ImageFileUpload(testimonial, imageFile);

        _testimonialService.AddTestimonial(testimonial);
        return RedirectToAction(nameof(Index));
    }

    private static void ImageFileUpload(Testimonial testimonial, IFormFile? imageFile)
    {
        if (imageFile != null)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/template/img/testimonial", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            testimonial.ImageUrl = fileName;
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult UpdateTestimonial(int id)
    {
        var testimonial = _testimonialService.GetAllTestimonials().Find(t => t.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }

        return View(testimonial);
    }

    [HttpPost]
    [Route("{id:int}")]
    public IActionResult UpdateTestimonial(Testimonial testimonial, IFormFile imageFile)
    {
        if (imageFile == null || imageFile == null)
        {
            var existingTestimonial = _testimonialService.GetAllTestimonials().Find(t => t.Id == testimonial.Id);
            testimonial.ImageUrl = existingTestimonial.ImageUrl;
        }
        else
        {
            ImageFileUpload(testimonial, imageFile);
        }

        _testimonialService.UpdateTestimonial(testimonial);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult DeleteTestimonial(int id)
    {
        var testimonial = _testimonialService.GetAllTestimonials().Find(t => t.Id == id);
        if (testimonial == null)
        {
            return NotFound();
        }
        
        _testimonialService.DeleteTestimonial(id);
        
        return RedirectToAction("Index", "AdminTestimonial");
    }
}