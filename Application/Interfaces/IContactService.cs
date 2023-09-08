using Domain.Entity;

namespace Application.Interfaces;

public interface IContactService
{
    void AddContact(Contact contact);
    
    void DeleteContact(Contact contact);
    
    void UpdateContact(Contact contact);
    
    List<Contact> GetAllContacts();
}