using PokePDF.API;
using PokePDF.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokePDF.Services
{
    public class PokeInformationService
    {
        public async Task<IEnumerable<string>> GetAllPokemonNamesAsync()
        {
            var PokeApi = RestService.For<IPokeAPI>("https://pokeapi.co");
            var PokemonList = await PokeApi.GetAllPokemonInformationAsync();

            return PokemonList.Results.Select(r => r.Name);
        }

        public async Task<Pokemon> GetPokemonInfoAsync(string name)
        {
            var PokeApi = RestService.For<IPokeAPI>("https://pokeapi.co");
            var Pokemon = await PokeApi.GetPokeInformationAsync(name);

            return Pokemon;
        }
        public async Task<IEnumerable<string>> GetPokemonByType(string type)
        {
            var PokeApi = RestService.For<IPokeAPI>("https://pokeapi.co");
            //Enum.TryParse(name, out TypeEnum pokeType);
            var PokemonNames = await PokeApi.GetAllPokemonByTypeAsync(type.ToLower());
            var PokemonStrings = new List<string>();
            foreach(var pokeName in PokemonNames.PokemonNames)
            {
                var p = pokeName.Name.Name;
                PokemonStrings.Add(p);
            }


            return PokemonStrings;
        }

        public IEnumerable<Pokemon> SortPokemonList(List<Pokemon> unsortedPokemon)
        {
            if (unsortedPokemon == null)
            {
                throw new ArgumentNullException();
            }
            var sortedPokemon = unsortedPokemon.OrderBy(n => n.Name).ToList();
            return sortedPokemon;
        }
    }
}
