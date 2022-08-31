using Bootcamp_API.Models;

namespace Bootcamp_API.Services;

public static class HallOfFameService
{
    static List<Pokemon> Shiny { get; }
    static int nextId = 3;
    static HallOfFameService()
    {
        Shiny = new List<Pokemon>
        {
            new Pokemon {id = 1, name = "Raticate", count = 3, userId = 1},
            new Pokemon {id = 2, name = "Audino", count = 4914, userId = 1}
        };
    }

    public static List<Pokemon> GetAll() => Shiny;

    public static Pokemon? Get(int id) => Shiny.FirstOrDefault(p => p.id == id);

    public static void Add(Pokemon pokemon)
    {
        pokemon.id = nextId++;
        Shiny.Add(pokemon);
    }

    public static void Delete(int id)
    {
        var pokemon = Get(id);
        if(pokemon is null)
            return;

        Shiny.Remove(pokemon);
    }

    public static void Update(Pokemon pokemon)
    {
        var index = Shiny.FindIndex(p => p.id == pokemon.id);
        if(index == -1)
            return;

        Shiny[index] = pokemon;
    }
}