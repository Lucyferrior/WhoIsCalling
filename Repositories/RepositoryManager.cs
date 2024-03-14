using Repositories.Contrats;
using Repositories.EFCore;

namespace Repositories;

public class RepositoryManager:IRepositoryManager
{
    private readonly RepositoryContext _context; //dbContextimiz

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
    }

    public IContactRepository Contacts => new ContactRepository(_context); //IoC kaydı yapılabilir 
    
    public void Save()
    {
        _context.SaveChanges();
    }
}