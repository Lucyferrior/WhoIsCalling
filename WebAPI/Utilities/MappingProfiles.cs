using AutoMapper;
using Entities;
using Entities.DataTransferObjects;

namespace WebAPI.Utilities;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<ContactDtoForInsertion, Contact>();
    }
}