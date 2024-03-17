using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public abstract record ContactDtoForManipulation
{
    [Required(ErrorMessage = "Name is required field.")]
    public string Name { get; init; }
    public string? SurName { get; init; }
    
    //Telefon numarası şu anda sadece 10 karakter olup olmamasıyla ölçülüyor. Daha sonraki zamanlarda daha ciddi kontroller yapılarak güncellenecek.
    [StringLength(maximumLength:10, MinimumLength = 10, ErrorMessage = "This is not a number")]
    public string PhoneNumber { get; init; }
}