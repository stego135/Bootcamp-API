using Bootcamp_API.Models;

namespace Bootcamp_API.Services;

public static class PokemonService
{
    static List<Pokemon> Pokemon { get; }
    static int nextId = 3;
    static PokemonService()
    {
        Pokemon = new List<Pokemon>
        {
            new Pokemon {Id = 1, Name = "Venusaur", Count = 400, UserId = 1},
            new Pokemon {Id = 2, Name = "Oshawott", Count = 24, UserId = 1}
        };
    }

    public static List<Pokemon> GetAll() => Pokemon;

    public static Pokemon? Get(int id) => Pokemon.FirstOrDefault(p => p.Id == id);

    public static void Add(Pokemon pokemon)
    {
        pokemon.Id = nextId++;
        Pokemon.Add(pokemon);
    }

    public static void Delete(int id)
    {
        var pokemon = Get(id);
        if(pokemon is null)
            return;

        Pokemon.Remove(pokemon);
    }

    public static void Update(Pokemon pokemon)
    {
        var index = Pokemon.FindIndex(p => p.Id == pokemon.Id);
        if(index == -1)
            return;

        Pokemon[index] = pokemon;
    }
}