using Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

[AllowAnonymous]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        contact.IsRead = true;
        _contactService.AddContact(contact);
        return RedirectToAction("Index", "Cake");
    }
}