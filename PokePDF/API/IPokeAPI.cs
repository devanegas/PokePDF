using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PokePDF.Models;
using Refit;

namespace PokePDF.API
{
    public interface IPokeAPI
    {
        [Get("api/v2/pokemon/{name}")]
        Task<Pokemon> GetPokeInformationAsync(string name);


        [Get("api/v2/pokemon?limit=9999")]
        Task<PokemonNames> GetAllPokemonInformationAsync();

    }
}
