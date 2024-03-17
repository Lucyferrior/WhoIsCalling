namespace Entities.DataTransferObjects;

public record ContactDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string? SurName { get; init; }
    public string PhoneNumber { get; init; }
}