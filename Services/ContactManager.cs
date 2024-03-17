using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Repositories.Contrats;
using Services.Contrats;

namespace Services;

public class ContactManager: IContactService
{
    private readonly IRepositoryManager _manager;//dependency injection
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    public ContactManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<ContactDto> GetAllContacts(bool trackChanges)
    {
        var entities = _manager.Contacts.GetAllContact(trackChanges);
        return _mapper.Map<IEnumerable<ContactDto>>(entities);
    }

    public ContactDto GetContactById(int id, bool trackChanges)
    {
        var entity = _manager.Contacts.GetOneContactById(id, trackChanges);
        if (entity is null)
            throw new ContactNotFoundException(id);
        var contact = _mapper.Map<ContactDto>(entity);
        return contact;
    }


    public ContactDto CreateOneContact(ContactDtoForInsertion contactDto)
    {
        if (contactDto is null)
            throw new ArgumentNullException();
        var entity = _mapper.Map<Contact>(contactDto);
        _manager.Contacts.CreateOneContact(entity);
        _manager.Save();

        return _mapper.Map<ContactDto>(entity);
    }
}