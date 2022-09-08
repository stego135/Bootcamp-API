using Bootcamp_API.Controllers;
using Bootcamp_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_API.Tests;

public class PokemonTest
{
    [Fact]
    public void Get_Returns_Correct_Number()
    {
        var controller = new PokemonController();

        var result = controller.GetAll();
        var list = result.Value;

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Get_Returns_Correct_List_Of_Pokemon()
    {
        var controller = new PokemonController();
        var sampleData = new List<Pokemon>
        {
            new Pokemon {Id = 1, Name = "Venusaur", Count = 400, UserId = 1},
            new Pokemon {Id = 2, Name = "Oshawott", Count = 24, UserId = 1}
        };

        var result = controller.GetAll();
        var list = result.Value;

        list.Should().BeEquivalentTo(sampleData);
    }

    [Fact]
    public void Get_With_Id_Returns_Correct_Pokemon()
    {
        var controller = new PokemonController();
        var sampleData = new Pokemon {Id = 2, Name = "Oshawott", Count = 24, UserId = 1};

        var result = controller.Get(2);
        var pokemon = result.Value;

        pokemon.Should().BeEquivalentTo(sampleData);
    }
}