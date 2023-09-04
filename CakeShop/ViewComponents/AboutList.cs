using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.ViewComponents;

public class AboutList : ViewComponent
{
    private readonly IAboutService _aboutService;

    public AboutList(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public IViewComponentResult Invoke()
    {
        var abouts = _aboutService.GetAllAbouts().ToList();
        return View(abouts);
    }
}