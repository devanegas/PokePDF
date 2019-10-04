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
            throw new NotImplementedException();
        }

        public async Task<Pokemon> GetPokemonInfoAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Pokemon>> GetPokemonByType(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pokemon>> SortPokemonList(List<Pokemon> unsortedPokemon)
        {
            throw new NotImplementedException();
        }
    }
}
