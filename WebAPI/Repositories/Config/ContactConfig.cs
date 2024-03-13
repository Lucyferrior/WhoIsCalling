using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Repositories.Config;

public class ContactConfig: IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasData(
            new Contact() { Id = 1, Name = "sefa", SurName = "köse", PhoneNumber = "5419714444" },
            new Contact() { Id = 2, Name = "sefa", SurName = "köse", PhoneNumber = "5419714555" },
            new Contact() { Id = 3, Name = "sefa", SurName = "köse", PhoneNumber = "5419714666" }
        );
    }
}