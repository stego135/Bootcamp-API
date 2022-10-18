using Bootcamp_API.Models;
using Bootcamp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Returns all users stored in the Users list
    /// </summary>
    /// <returns>All users in the User list</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<User>> GetAll() =>
        _service.GetAll();

    /// <summary>
    /// Returns a single user with the id provided
    /// </summary>
    /// <param name="id">The id of the user desired</param>
    /// <returns>The user that has the id specified</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> Get(int id)
    {
        var user = _service.Get(id);

        if(user == null)
            return NotFound();

        return user;
    }

    /// <summary>
    /// Creates a new user to be stored in the Users list
    /// </summary>
    /// <returns>A response of success if added</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(User user)
    {            
        _service.Add(user);
        return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
    }

    /// <summary>
    /// Updates a user in the Users list
    /// </summary>
    /// <param name="id">The id of the user to be updated</param>
    /// <returns>An empty response if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();
           
        var existingUser = _service.Get(id);
        if(existingUser is null)
            return NotFound();
   
        _service.Update(user);           
   
        return NoContent();
    }

    /// <summary>
    /// Deletes a user in the Users list
    /// </summary>
    /// <param name="id">The id of the user to be deleted</param>
    /// <returns>An empty response if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var user = _service.Get(id);
   
        if (user is null)
            return NotFound();
       
        _service.Delete(id);
   
        return NoContent();
    }
}