using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.ViewComponents;

public class RelatedCakesList : ViewComponent
{
    private readonly ICakeService _cakeService;

    public RelatedCakesList(ICakeService cakeService)
    {
        _cakeService = cakeService;
    }

    public IViewComponentResult Invoke()
    {
        var id = Convert.ToInt32(ViewContext.RouteData.Values["id"]);
        var relatedCakes = _cakeService.GetRelatedCakes(id).ToList();
        return View(relatedCakes);
    }
}