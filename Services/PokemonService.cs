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
            new Pokemon {id = 1, name = "Venusaur", count = 400, userId = 1},
            new Pokemon {id = 2, name = "Oshawott", count = 24, userId = 1}
        };
    }

    public static List<Pokemon> GetAll() => Pokemon;

    public static Pokemon? Get(int id) => Pokemon.FirstOrDefault(p => p.id == id);

    public static void Add(Pokemon pokemon)
    {
        pokemon.id = nextId++;
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
        var index = Pokemon.FindIndex(p => p.id == pokemon.id);
        if(index == -1)
            return;

        Pokemon[index] = pokemon;
    }
}