using System.Linq.Expressions;
using Entities;
using Repositories.Contrats;

namespace Repositories.EFCore;

public class ContactRepository: RepositoryBase<Contact>, IContactRepository
{
    public ContactRepository(RepositoryContext context) : base(context)
    {
        
    }

    public IQueryable<Contact> GetAllContact(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(c => c.Id);

    public Contact? GetOneContactById(int id, bool trackChanges) =>
        FindByCondition(c => c.Id == id, trackChanges)
            .SingleOrDefault();

    public void CreateOneContact(Contact contact) => Create(contact);

    public void UpdateOneContact(Contact contact) => Update(contact);

    public void DeleteOneContact(Contact contact) => Delete(contact);
}