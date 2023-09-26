using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class ErrorController : Controller
{
    public IActionResult Index()
    {
        var exceptionHandlerPathFeature =
            HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
        
        ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
        ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
        return View();
    }
}