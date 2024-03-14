using Entities;
using Repositories.Contrats;
using Services.Contrats;

namespace Services;

public class ContactManager: IContactService
{
    private readonly IRepositoryManager _manager;//dependency injection
    private readonly ILoggerService _logger;

    public ContactManager(IRepositoryManager manager, ILoggerService logger)
    {
        _manager = manager;
        _logger = logger;
    }

    public IEnumerable<Contact> GetAllContacts(bool trackChanges)
    {
        var entities = _manager.Contacts.GetAllContact(trackChanges);
        return entities;
    }

    public Contact GetContactById(int id, bool trackChanges)
    {
        var entity = _manager.Contacts.GetOneContactById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Contact with id: {id} could not found.");
        return entity;
    }
    public Contact CreateOneContact(Contact contact)
    {
        if (contact is null)
            throw new ArgumentNullException();
        _manager.Contacts.CreateOneContact(contact);
        _manager.Save();
        return contact;
    }
}