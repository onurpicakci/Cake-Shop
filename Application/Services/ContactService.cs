using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public void AddContact(Contact contact)
    {
        _contactRepository.AddContact(contact);
    }

    public void DeleteContact(Contact contact)
    {
        _contactRepository.DeleteContact(contact);
    }

    public void UpdateContact(Contact contact)
    {
        _contactRepository.UpdateContact(contact);
    }

    public List<Contact> GetAllContacts()
    {
        return _contactRepository.GetAllContacts();
    }
}