using Application.Interfaces;
using CakeShop.ViewModels;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeService _cakeService;
        private readonly ICategoryService  _categoryService;
        
        public CakeController(ICakeService cakeService, ICategoryService  categoryService)
        {
            _cakeService = cakeService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _cakeService.GetAllCakes().ToList();
            return View(values);
        }
        
        public ViewResult Shop()
        {
            var cakes = _cakeService.GetAllCakes().ToList();
            return View(cakes);
        }
        
        public IActionResult Details(int id)
        {
            var cake = _cakeService.GetCakeById(id);
            if (cake == null)
                return NotFound();

            return View(cake);
        }
        
        public IActionResult Search()
        {
            return View();
        }
        
    }
}