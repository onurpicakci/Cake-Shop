using CakeShop.ViewModels;
using DataAccess.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly ICategoryRepository  _categoryRepository;
        
        public CakeController(ICakeRepository cakeRepository, ICategoryRepository  categoryRepository)
        {
            _cakeRepository = cakeRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var values = _cakeRepository.GetAllCakes().ToList();
            return View(values);
        }
        
        public ViewResult List(string category)
        {
            List<Cake> cakes;
            string currentCategory;
            
            if (string.IsNullOrEmpty(category))
            {
                cakes = _cakeRepository.GetAllCakes().ToList();
                currentCategory = "All cakes";
            }
            else
            {
                cakes = _cakeRepository.GetAllCakes().Where(c => c.Category.Name == category).ToList();
                currentCategory = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == category)?.Name;
            }
            
            return View(new CakeListViewModel(cakes, currentCategory));
        }
        
        public IActionResult Details(int id)
        {
            var cake = _cakeRepository.GetCakeById(id);
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