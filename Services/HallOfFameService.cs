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
            new Pokemon {Id = 1, Name = "Raticate", Count = 3, UserId = 1},
            new Pokemon {Id = 2, Name = "Audino", Count = 4914, UserId = 1}
        };
    }

    public static List<Pokemon> GetAll() => Shiny;

    public static Pokemon? Get(int id) => Shiny.FirstOrDefault(p => p.Id == id);

    public static void Add(Pokemon pokemon)
    {
        pokemon.Id = nextId++;
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
        var index = Shiny.FindIndex(p => p.Id == pokemon.Id);
        if(index == -1)
            return;

        Shiny[index] = pokemon;
    }
}