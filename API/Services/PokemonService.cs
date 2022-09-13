using Bootcamp_API.Models;
using Bootcamp_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_API.Services;

public class PokemonService
{
    private readonly PokemonContext _context;

    public PokemonService(PokemonContext context)
    {
        _context = context;
    }

    public List<Pokemon> GetAll()
    {
        return _context.Pokemon.ToList();
    }

    public Pokemon? Get(int id)
    {
        return _context.Pokemon.SingleOrDefault(p => p.Id == id);
    }

    public Pokemon Add(Pokemon pokemon)
    {
        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();

        return pokemon;
    }

    public void Delete(int id)
    {
        var pokemonToDelete = _context.Pokemon.Find(id);
        if (pokemonToDelete is not null)
        {
            _context.Pokemon.Remove(pokemonToDelete);
            _context.SaveChanges();
        }
    }

    public void Update(Pokemon pokemon)
    {
        var existingPokemon = _context.Pokemon.SingleOrDefault(p => p.Id == pokemon.Id);
        existingPokemon.Name = pokemon.Name;
        existingPokemon.Count = pokemon.Count;
        existingPokemon.UserId = pokemon.UserId;

        _context.SaveChanges();
    }
}