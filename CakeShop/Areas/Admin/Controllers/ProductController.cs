using Application.Interfaces;
using CakeShop.Areas.Admin.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Product/[action]")]
public class ProductController : Controller
{
    private readonly ICakeService _cakeService;
    private readonly ICategoryService _categoryService;

    public ProductController(ICakeService cakeService, ICategoryService categoryService)
    {
        _cakeService = cakeService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _cakeService.GetAllCakes().ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        var categories = _categoryService.GetAllCategories();
        var viewModel = new AddCakeViewModel
        {
            Categories = categories
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddProduct(AddCakeViewModel viewModel, List<IFormFile?> imageFiles)
    {
        if (imageFiles != null && imageFiles.Count > 0)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", "img", "shop");

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            for (int i = 0; i < imageFiles.Count; i++)
            {
                var imageFile = imageFiles[i];

                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName; 

                    using (var stream = new FileStream(Path.Combine(imagePath, uniqueFileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    if (i == 0)
                        viewModel.Cake.ImageThumbnailUrl = uniqueFileName;
                    else if (i == 1)
                        viewModel.Cake.ImageUrl = uniqueFileName;
                    else if (i == 2)
                        viewModel.Cake.ImageUrl2 = uniqueFileName;
                    else if (i == 3)
                        viewModel.Cake.ImageUrl3 = uniqueFileName;
                    else if (i == 4)
                        viewModel.Cake.ImageUrl4 = uniqueFileName;
                    else if (i == 5)
                        viewModel.Cake.ImageUrl5 = uniqueFileName;
                    else if (i == 6)
                        viewModel.Cake.ImageUrl6 = uniqueFileName;
                    
                }
            }
        }

        _cakeService.Insert(viewModel.Cake);
        return RedirectToAction("Index", "Product");
    }
}