using Microsoft.EntityFrameworkCore;
using Bootcamp_API.Models;

namespace Bootcamp_API.Data;

public class PokemonContext : DbContext
{
    public PokemonContext (DbContextOptions<PokemonContext> options)
        : base(options)
    {
    }

    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<Shiny> Shinies { get; set; }
    public DbSet<User> Users { get; set; }
}