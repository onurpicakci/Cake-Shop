using Domain.Entity;

namespace DataAccess.Interfaces;

public interface IContactRepository
{
    void AddContact(Contact contact);
    
    void DeleteContact(Contact contact);
    
    void UpdateContact(Contact contact);
    
    List<Contact> GetAllContacts();
}