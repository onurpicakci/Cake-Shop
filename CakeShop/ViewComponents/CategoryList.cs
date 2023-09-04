using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.ViewComponents;

public class CategoryList : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryList(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _categoryService.GetAllCategories();
        return View(categories);
    }
}