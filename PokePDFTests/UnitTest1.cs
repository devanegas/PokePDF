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
            string type = "flying";
            //var PokeService = new Mock<PokeInformationService>();
            var PokeService = new PokeInformationService();
            var Pokemons = await PokeService.GetPokemonByType(type);

            foreach(var pokemon in Pokemons)
            {
                if(pokemon.PokemonTypes[0].PokemonType.Name.Equals(type) == false)
                {
                    if (pokemon.PokemonTypes[1].PokemonType.Name.Equals(type) == false)
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

        [Test]
        public void UserSendsIEnumerableOfPokemon_GetsAnIEnumerableofStrings()
        {
            //make a list/enumerable data type of pokemon 3 fake pokemon
            var PokeList = new List<Pokemon> {
                                new Pokemon {Name = "Diego" },
                                new Pokemon {Name = "Brandon" },
                                new Pokemon {Name = "Kaydon"}};
            //call our function with that list
            var service = new PokeInformationService();
            var PokeStrings = service.PokemonEnumerabletoStringConverter(PokeList);
            //check to make sure that the list is only strings matching pokemon name
            var i = 0;
            foreach (var PokeString in PokeStrings)
            {
                if (!PokeString.Equals(PokeList[i]))
                {
                    Assert.Fail();
                }

                i++;
            }

            Assert.Pass();
        }
    }
}