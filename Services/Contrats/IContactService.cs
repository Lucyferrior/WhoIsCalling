using Entities;
using Entities.DataTransferObjects;

namespace Services.Contrats;

public interface IContactService
{
    IEnumerable<ContactDto> GetAllContacts(bool trackChanges);
    ContactDto GetContactById(int id, bool trackChanges);
    ContactDto CreateOneContact(ContactDtoForInsertion contactDto);
}