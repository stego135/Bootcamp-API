using Bootcamp_API.Models;
using Bootcamp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    public PokemonController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pokemon>> GetAll() =>
        PokemonService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pokemon> Get(int id)
    {
        var pokemon = PokemonService.Get(id);

        if(pokemon == null)
            return NotFound();

        return pokemon;
    }

    [HttpPost]
    public IActionResult Create(Pokemon pokemon)
    {            
        PokemonService.Add(pokemon);
        return CreatedAtAction(nameof(Create), new { id = pokemon.id }, pokemon);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pokemon pokemon)
    {
        if (id != pokemon.id)
            return BadRequest();
           
        var existingPokemon = PokemonService.Get(id);
        if(existingPokemon is null)
            return NotFound();
   
        PokemonService.Update(pokemon);           
   
        return NoContent();
}

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pokemon = PokemonService.Get(id);
   
        if (pokemon is null)
            return NotFound();
       
        PokemonService.Delete(id);
   
        return NoContent();
    }
}