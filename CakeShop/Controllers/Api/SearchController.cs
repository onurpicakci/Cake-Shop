using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CakeShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
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
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
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
        
    }
}
