using Bootcamp_API.Models;
using Bootcamp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {            
        UserService.Add(user);
        return CreatedAtAction(nameof(Create), new { id = user.id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.id)
            return BadRequest();
           
        var existingUser = UserService.Get(id);
        if(existingUser is null)
            return NotFound();
   
        UserService.Update(user);           
   
        return NoContent();
}

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UserService.Get(id);
   
        if (user is null)
            return NotFound();
       
        UserService.Delete(id);
   
        return NoContent();
    }
}