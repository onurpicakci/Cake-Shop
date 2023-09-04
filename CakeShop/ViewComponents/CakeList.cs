using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.ViewComponents;

public class CakeList : ViewComponent
{
    private readonly ICakeService _cakeService;
    
    public CakeList(ICakeService cakeService)
    {
        _cakeService = cakeService;
    }
    
    public IViewComponentResult Invoke()
    {
        var cakes = _cakeService.GetAllCakes();
        return View(cakes);
    }
}