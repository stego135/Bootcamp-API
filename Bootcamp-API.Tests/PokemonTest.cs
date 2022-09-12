using Bootcamp_API.Controllers;
using Bootcamp_API.Models;
using Bootcamp_API.Services;
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

    [Fact]
    public void Get_With_Wrong_Id_Returns_Null()
    {
        var controller = new PokemonController();

        var result = controller.Get(3);
        var pokemon = result.Value;

        Assert.Equal(null, pokemon);
    }

    [Fact]
    public void Add_And_Delete_Increases_List_Correctly()
    {
        var controller = new PokemonController();
        var newPokemon = new Pokemon {Id = 1, Name = "Mew", Count = 5025, UserId = 1};

        var result = controller.Create(newPokemon);
        var pokemonResult = controller.Get(3);
        var pokemon = pokemonResult.Value;

        pokemon.Should().BeEquivalentTo(newPokemon);

        controller.Delete(3);
        var listResult = controller.GetAll();
        var list = listResult.Value;

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Update_Updates_Pokemon_Correctly()
    {
        var controller = new PokemonController();
        var updatedPokemon = new Pokemon {Id = 2, Name = "Oshawott", Count = 30, UserId = 1};

        var result = controller.Update(2, updatedPokemon);
        var pokemonResult = controller.Get(2);
        var pokemon = pokemonResult.Value;

        pokemon.Should().BeEquivalentTo(updatedPokemon);
        updatedPokemon = new Pokemon {Id = 2, Name = "Oshawott", Count = 24, UserId = 1};
        controller.Update(2, updatedPokemon);
    }
}