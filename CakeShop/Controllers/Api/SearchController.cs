using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CakeShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly ICakeService _cakeService;

        public SearchController(ICakeService cakeService)
        {
            _cakeService = cakeService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _cakeService.GetAllCakes();
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_cakeService.GetAllCakes().Any(x => x.Id  == id))
                return NotFound();
            return Ok(_cakeService.GetAllCakes().Where(x => x.Id == id));
        }
        
        [HttpPost]
        public IActionResult SearchCakes([FromBody] string searchQuery)
        {
            IEnumerable<Cake> cakes = new List<Cake>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                cakes = _cakeService.SearchCakes(searchQuery);
            }
            return new JsonResult(cakes);
        }
        
        [HttpGet("category/{categoryName}")]
        public IActionResult GetCakesByCategoryName(string categoryName)
        {
            IEnumerable<Cake> cakes = new List<Cake>();

            if (!string.IsNullOrEmpty(categoryName))
            {
                cakes = _cakeService.GetCakesByCategoryName(categoryName);
            }
            return new JsonResult(cakes);
        }
        
    }
}
