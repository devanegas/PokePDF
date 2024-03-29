﻿using PokePDF.API;
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
        public async Task<IEnumerable<Pokemon>> GetPokemonByType(string name)
        {
            var PokeApi = RestService.For<IPokeAPI>("https://pokeapi.co");
            //Enum.TryParse(name, out TypeEnum pokeType);
            var PokemonNames = await PokeApi.GetAllPokemonByTypeAsync(name.ToLower());
            var Pokemon = new List<Pokemon>();
            foreach(var pokeName in PokemonNames.PokemonNames)
            {
                var p = await GetPokemonInfoAsync(pokeName.Name.Name);
                Pokemon.Add(p);
            }


            return Pokemon;
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


        public IEnumerable<string> PokemonEnumerabletoStringConverter(IEnumerable<Pokemon> pokemons)
        {
            var PokemonList = new List<string>();

            foreach(var pokemon in pokemons)
            {
                PokemonList.Add(pokemon.ToString());
            }

            return PokemonList;
        }

        //public async Task<bool> IsPokemonNameValid(string name)
        //{
        //    var PokeApi = RestService.For<IPokeAPI>("https://pokeapi.co");
        //    try
        //    {
        //        await PokeApi.GetPokeInformationAsync(name);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

        public bool IsPokemonNameValid(string name, IEnumerable<string> allnames)
        {
            return allnames.Contains(name);
        }
    }
}
