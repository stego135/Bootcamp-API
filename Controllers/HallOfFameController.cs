using Bootcamp_API.Models;
using Bootcamp_API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bootcamp_API.Controllers;

[ApiController]
[Route("[controller]")]
public class HallOfFameController : ControllerBase
{
    public HallOfFameController()
    {
    }

    /// <summary>
    /// Returns all Pokemon stored in the Hall of Fame
    /// </summary>
    /// <returns>All Pokemon in Hall of Fame</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Pokemon>> GetAll() =>
        HallOfFameService.GetAll();

    /// <summary>
    /// Returns a single Pokemon with the id provided
    /// </summary>
    /// <param name="id">The id of the Pokemon desired</param>
    /// <returns>The Pokemon that has the id specified</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pokemon> Get(int id)
    {
        var pokemon = HallOfFameService.Get(id);

        if(pokemon == null)
            return NotFound();

        return pokemon;
    }

    /// <summary>
    /// Creates a new Pokemon to be stored in the Hall of Fame
    /// </summary>
    /// <returns>A response of success if added</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(Pokemon pokemon)
    {            
        HallOfFameService.Add(pokemon);
        return CreatedAtAction(nameof(Create), new { id = pokemon.id }, pokemon);
    }

    /// <summary>
    /// Updates a Pokemon in the Hall of Fame
    /// </summary>
    /// <param name="id">The id of the Pokemon to be updated</param>
    /// <returns>An empty response if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, Pokemon pokemon)
    {
        if (id != pokemon.id)
            return BadRequest();
           
        var existingPokemon = HallOfFameService.Get(id);
        if(existingPokemon is null)
            return NotFound();
   
        HallOfFameService.Update(pokemon);           
   
        return NoContent();
    }

    /// <summary>
    /// Deletes a Pokemon in the Hall of Fame
    /// </summary>
    /// <param name="id">The id of the Pokemon to be deleted</param>
    /// <returns>An empty response if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var pokemon = HallOfFameService.Get(id);
   
        if (pokemon is null)
            return NotFound();
       
        HallOfFameService.Delete(id);
   
        return NoContent();
    }
}