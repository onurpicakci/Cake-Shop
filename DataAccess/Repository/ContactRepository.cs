using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class ContactRepository : IContactRepository
{
    private readonly CakeShopDbContext _context;

    public ContactRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
    }

    public void DeleteContact(Contact contact)
    {
        _context.Contacts.Remove(contact);
        _context.SaveChanges();
    }

    public void UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        _context.SaveChanges();
    }

    public List<Contact> GetAllContacts()
    {
        return _context.Contacts.ToList();
    }
}