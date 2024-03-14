using Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contrats;
using Repositories.EFCore;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IRepositoryManager _manager;    //kaydı IoC ile yapılıyor

    public ContactController(IRepositoryManager manager)
    {
        _manager = manager;
    }


    [HttpGet]
    public IActionResult GetAllContact()//bu method şimdilik tüm verileri getiriyor.
    {
        var contacts = _manager.Contacts.GetAllContact(false);
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAllContactById([FromRoute(Name = "id")] int id)
    {
        var entity = _manager
            .Contacts
            .GetOneContactById(id,false);
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
            _manager
                .Contacts
                .CreateOneContact(contact);
            _manager.Save();
            return StatusCode(201, contact);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}