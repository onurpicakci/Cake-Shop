using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Contact/[action]")]
public class AdminContactController : Controller
{
    private readonly IContactService _contactService;

    public AdminContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        var incomingMessages = _contactService.GetAllContacts();
        return View(incomingMessages);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult SeeDetails(int id)
    {
        var incomingMessage = _contactService.GetAllContacts().FirstOrDefault(c => c.Id == id);
        return View(incomingMessage);
    }
}