using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Order/[action]")]
public class AdminOrderController : Controller
{
    private readonly IOrderService _orderService;
    
    public AdminOrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var orders = _orderService.GetAllOrders();
        return View(orders);
    }
}