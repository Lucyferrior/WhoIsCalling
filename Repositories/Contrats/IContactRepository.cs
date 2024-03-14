using Entities;

namespace Repositories.Contrats;

public interface IContactRepository: IRepositoryBase<Contact>
{
    IQueryable<Contact> GetAllContact(bool trackChanges);
    IQueryable<Contact> GetOneContactById(int id, bool trackChanges);
    void CreateOneContact(Contact contact);
    void UpdateOneContact(Contact contact);
    void DeleteOneContact(Contact contact);
}