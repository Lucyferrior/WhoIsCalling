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
    public IActionResult GetAllContact()
    {
        var contacts = _context.Contacts.ToList();
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAllContactById([FromRoute(Name = "id")] int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult CreateContact([FromBody] Contact contact)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateContact([FromRoute(Name = "id")] int id,
        [FromBody] Contact contact)
    {
        throw new NotImplementedException();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync([FromRoute(Name = "id")] int id)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PatchBookAsync([FromRoute(Name = "id")] int id,
        [FromBody] JsonPatchDocument<Contact> contact)
    {
        throw new NotImplementedException();
    }
    

}