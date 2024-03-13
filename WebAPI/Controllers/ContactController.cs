using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly RepositoryContext _context;    //kaydı IoC ile yapılıyor

    public ContactController(RepositoryContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllContact()//bu method şimdilik tüm verileri getiriyor.
    {
        var contacts = _context.Contacts.ToList();
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAllContactById([FromRoute(Name = "id")] int id)
    {
        var entity = _context
            .Contacts
            .FirstOrDefault(c => c.Id == id);
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
            _context
                .Contacts
                .Add(contact);
            _context.SaveChanges();
            return StatusCode(201, contact);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}