using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}