using Application.Interfaces;
using CakeShop.Areas.Admin.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
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
        ImageFileUpload(viewModel, imageFiles);

        _cakeService.Insert(viewModel.Cake);
        return RedirectToAction("Index", "Product");
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult UpdateProduct(int id)
    {
        var categories = _categoryService.GetAllCategories();
        var cake = _cakeService.GetCakeById(id);
        var viewModel = new AddCakeViewModel
        {
            Cake = cake,
            Categories = categories
        };

        return View(viewModel);
    }
    
    [HttpPost]
    [Route("{id:int}")]
    public IActionResult UpdateProduct(AddCakeViewModel viewModel, List<IFormFile?> imageFiles)
    {
        if (imageFiles == null || imageFiles.All(file => file == null))
        {
            var existingCake = _cakeService.GetCakeById(viewModel.Cake.Id);
            viewModel.Cake.ImageThumbnailUrl = existingCake.ImageThumbnailUrl;
            viewModel.Cake.ImageUrl = existingCake.ImageUrl;
            viewModel.Cake.ImageUrl2 = existingCake.ImageUrl2;
            viewModel.Cake.ImageUrl3 = existingCake.ImageUrl3;
            viewModel.Cake.ImageUrl4 = existingCake.ImageUrl4;
            viewModel.Cake.ImageUrl5 = existingCake.ImageUrl5;
            viewModel.Cake.ImageUrl6 = existingCake.ImageUrl6;
        }
        else
        {
            ImageFileUpload(viewModel, imageFiles);
        }

        _cakeService.Update(viewModel.Cake);
        return RedirectToAction("Index", "Product");
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var cake = _cakeService.GetCakeById(id);
        _cakeService.Delete(cake);
        return RedirectToAction("Index", "Product");
    }

    private static void ImageFileUpload(AddCakeViewModel viewModel, List<IFormFile?> imageFiles)
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

                    using (var stream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    if (i == 0)
                        viewModel.Cake.ImageThumbnailUrl = fileName;
                    else if (i == 1)
                        viewModel.Cake.ImageUrl = fileName;
                    else if (i == 2)
                        viewModel.Cake.ImageUrl2 = fileName;
                    else if (i == 3)
                        viewModel.Cake.ImageUrl3 = fileName;
                    else if (i == 4)
                        viewModel.Cake.ImageUrl4 = fileName;
                    else if (i == 5)
                        viewModel.Cake.ImageUrl5 = fileName;
                    else if (i == 6)
                        viewModel.Cake.ImageUrl6 = fileName;
                }
            }
        }
    }
}