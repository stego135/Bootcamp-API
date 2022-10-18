using Bootcamp_API.Models;
using Bootcamp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    PokemonService _service;

    public PokemonController(PokemonService service)
    {
        _service = service;
    }

    /// <summary>
    /// Returns all Pokemon stored in the Pokemon list
    /// </summary>
    /// <returns>All Pokemon in the Pokemon list</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Pokemon>> GetAll() =>
        _service.GetAll();

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
        var pokemon = _service.Get(id);

        if(pokemon == null)
            return NotFound();

        return pokemon;
    }

    /// <summary>
    /// Creates a new Pokemon to be stored in the Pokemon list
    /// </summary>
    /// <returns>A response of success if added</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(Pokemon pokemon)
    {            
        _service.Add(pokemon);
        return CreatedAtAction(nameof(Create), new { id = pokemon.Id }, pokemon);
    }

    /// <summary>
    /// Updates a Pokemon in the Pokemon list
    /// </summary>
    /// <param name="id">The id of the Pokemon to be updated</param>
    /// <returns>An empty response if successful</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, Pokemon pokemon)
    {
        if (id != pokemon.Id)
            return BadRequest();
           
        var existingPokemon = _service.Get(id);
        if(existingPokemon is null)
            return NotFound();
   
        _service.Update(pokemon);           
   
        return NoContent();
    }

    /// <summary>
    /// Deletes a Pokemon in the Pokemon list
    /// </summary>
    /// <param name="id">The id of the Pokemon to be deleted</param>
    /// <returns>An empty response if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var pokemon = _service.Get(id);
   
        if (pokemon is null)
            return NotFound();
       
        _service.Delete(id);
   
        return NoContent();
    }
}