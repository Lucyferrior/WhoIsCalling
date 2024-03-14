using Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contrats;
using Repositories.EFCore;
using Services.Contrats;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IServiceManager _manager;

    public ContactController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllContact()//bu method şimdilik tüm verileri getiriyor.
    {
        var contacts = _manager.ContactService.GetAllContacts(false);
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAllContactById([FromRoute(Name = "id")] int id)
    {
        var entity = _manager
            .ContactService
            .GetContactById(id,false);
        if (entity is null) return NotFound();

        return Ok(entity);
    }

    [HttpPost]
    public IActionResult CreateContact([FromBody] Contact contact)
    {
        try
        {
            if (contact is null)
                return BadRequest();
            var entity = _manager
                .ContactService
                .CreateOneContact(contact);
            return StatusCode(201, entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}