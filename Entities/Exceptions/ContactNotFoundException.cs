namespace Entities.Exceptions;

public sealed class ContactNotFoundException : NotFoundException
{
    public ContactNotFoundException(int id) : base($"Contact with id: {id} could not found")
    {
    }
}