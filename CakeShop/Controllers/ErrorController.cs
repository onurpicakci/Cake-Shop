using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class ErrorController : Controller
{
    public IActionResult Index()
    {
        var statusCode = HttpContext.Response.StatusCode;
        switch (statusCode)
        {
            case 404:
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                break;
            case 500:
                ViewBag.ErrorMessage = "Sorry, something went wrong on the server";
                break;
        }
        return View();
    }
}