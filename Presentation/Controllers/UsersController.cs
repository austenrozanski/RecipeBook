using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    //private DataContext _context { get; }
    private readonly ISender _sender;

    protected UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        //var users = await _context.Users.ToListAsync();
        //return Ok(users);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        //var user = await _context.Users.FindAsync(id);
        //return Ok(user);
        return Ok();
    }
}