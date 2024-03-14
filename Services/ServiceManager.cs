using Repositories.Contrats;
using Services.Contrats;

namespace Services;

public class ServiceManager:IServiceManager
{
    private readonly Lazy<IContactService> _contactService;
    public ServiceManager(IRepositoryManager _manager, ILoggerService _logger)
    {
        _contactService = new Lazy<IContactService>(() => new ContactManager(_manager,_logger));
    }

    public IContactService ContactService => _contactService.Value;
}