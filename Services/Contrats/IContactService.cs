using Entities;

namespace Services.Contrats;

public interface IContactService
{
    IEnumerable<Contact> GetAllContacts(bool trackChanges);
    Contact GetContactById(int id, bool trackChanges);
    Contact CreateOneContact(Contact contact);
}