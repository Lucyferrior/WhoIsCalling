using Repositories.Contrats;
using Services.Contrats;

namespace Services;

public class ServiceManager:IServiceManager
{
    private readonly Lazy<IContactService> _contactService;
    public ServiceManager(IRepositoryManager _manager)
    {
        _contactService = new Lazy<IContactService>(() => new ContactManager(_manager));
    }

    public IContactService ContactService => _contactService.Value;
}