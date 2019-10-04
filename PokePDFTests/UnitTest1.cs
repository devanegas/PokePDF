using Moq;
using NUnit.Framework;
using PokePDF.Models;
using PokePDF.Services;
using System.Collections.Generic;

namespace PokePDFTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserEntersPokemonName_GetsPokemonInformationBack()
        {
            string name = "Bulbasaur";
            var PokeService = new Mock<PokeInformationService>();
            var Pokemon = PokeService.Object.GetPokemonInfoAsync(name);

            if (Pokemon.Result.Name.Equals(name))
            {
                Assert.IsNotNull(Pokemon);
            }

            Assert.Fail();
        }

        [Test]
        public void UserEntersPokemonType_GetsAllPokemonOfThatType()
        {
            string type = "Flying";
            var PokeService = new Mock<PokeInformationService>();
            var Pokemons = PokeService.Object.GetPokemonByType(type);

            foreach(var pokemon in Pokemons.Result)
            {
                if(pokemon.PokemonTypes[0].PokemonType.Name.Equals(type))
                {
                    Assert.IsNotNull(Pokemons);
                }
            }

            Assert.Fail();
        }

        [Test]
        public void UserFiltersPokemonByName_GetsAllPokemonSortedByFirstLetterOfName()
        {
            var PokeService = new Mock<PokeInformationService>();
            var SortedPokemonSolution = new List<Pokemon>()
            {
                new Pokemon(){ Name = "Arbok"},
                new Pokemon(){ Name = "Bulbasaur"},
                new Pokemon(){ Name = "Darkrai"},
                new Pokemon(){ Name = "Ditto"},
                new Pokemon(){ Name = "Giratina"},
                new Pokemon(){ Name = "Zoroark"}
            };
            var UnsortedPokemon = new List<Pokemon>()
            {
                new Pokemon(){ Name = "Arbok"},
                new Pokemon(){ Name = "Zoroark"},
                new Pokemon(){ Name = "Giratina"},
                new Pokemon(){ Name = "Bulbasaur"},
                new Pokemon(){ Name = "Darkrai"},
                new Pokemon(){ Name = "Ditto"}
            };

            var SortedPokemons = PokeService.Object.SortPokemonList(UnsortedPokemon);

            int i = 0;
            foreach(var pokemon in SortedPokemons.Result)
            {
                if (pokemon.Name.Equals(SortedPokemonSolution[i].Name))
                {
                    i++;
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }
}