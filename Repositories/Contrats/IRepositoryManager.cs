namespace Repositories.Contrats;

public interface IRepositoryManager
{
    IContactRepository Contacts { get; }
    void Save();
}