using Moq;
using NUnit.Framework;
using PokePDF.Models;
using PokePDF.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokePDFTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task UserEntersPokemonName_GetsPokemonInformationBack()
        {
            string name = "pikachu";
            var PokeService = new Mock<PokeInformationService>();
            var Pokemon = await PokeService.Object.GetPokemonInfoAsync(name);

            if (Pokemon.Name.Equals(name))
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task UserEntersPokemonType_GetsAllPokemonOfThatType()
        {
            PokemonByType type = new PokemonByType { TypeName = "flying" };
            //var PokeService = new Mock<PokeInformationService>();

            foreach(var pokemon in Pokemons)
            {
                if(pokemon.Equals(type) == false)
                {
                    if (pokemon.Equals(type) == false)
                        Assert.Fail();
                }
            }

            Assert.Pass();


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
            foreach(var pokemon in SortedPokemons)
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