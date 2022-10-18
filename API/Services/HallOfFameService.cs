using Bootcamp_API.Models;
using Bootcamp_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_API.Services;

public class HallOfFameService
{
    private readonly PokemonContext _context;

    public HallOfFameService(PokemonContext context)
    {
        _context = context;
    }

    public List<Shiny> GetAll()
    {
        return _context.Shinies.ToList();
    }

    public Shiny? Get(int id)
    {
        return _context.Shinies.SingleOrDefault(p => p.Id == id);
    }

    public Shiny Add(Shiny shiny)
    {
        _context.Shinies.Add(shiny);
        _context.SaveChanges();

        return shiny;
    }

    public void Delete(int id)
    {
        var shinyToDelete = _context.Shinies.Find(id);
        if (shinyToDelete is not null)
        {
            _context.Shinies.Remove(shinyToDelete);
            _context.SaveChanges();
        }
    }

    public void Update(Shiny shiny)
    {
        var existingShiny = _context.Shinies.SingleOrDefault(p => p.Id == shiny.Id);
        existingShiny.Name = shiny.Name;
        existingShiny.Count = shiny.Count;
        existingShiny.UserId = shiny.UserId;

        _context.SaveChanges();
    }
}