using PokePDF.API;
using PokePDF.Models;
using PokePDF.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokePDF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private PokeInformationService _pokeService;
        public ICommand PrintAllPokemon { get; }
        public ICommand SearchPokemon { get; }
        public ICommand SortByType { get; }

        public MainWindowViewModel()
        {

            _pokeService = new PokeInformationService();
            SearchPokemon = new AwaitableDelegateCommand(SearchPokemonAsync);
            SortByType = new AwaitableDelegateCommand(SortPokemonByType);
            SearchPokemonAsync();
            PrintAllPokemonAsync();
        }


        public async Task PrintAllPokemonAsync()
        {
            var pokemon = await _pokeService.GetAllPokemonNamesAsync();
            Pokemon = await _pokeService.GetPokemonInfoAsync(PokemonName);
            AllPokemonNames = pokemon;
        }

        public async Task SearchPokemonAsync()
        {
            var pokemonInfo = await _pokeService.GetPokemonInfoAsync(PokemonName);
            Pokemon = pokemonInfo;
        }

        public async Task SortPokemonByType()
        {
            var pokemonInfo = await _pokeService.GetPokemonByType(PokemonTypeProperty);
            AllPokemonNames = pokemonInfo;
        }


        private string pokemonTypeProperty;

        public string PokemonTypeProperty
        {
            get { return pokemonTypeProperty; }
            set { SetProperty(ref pokemonTypeProperty , value); }
        }


        private Pokemon pokemon;

        public Pokemon Pokemon
        {
            get { return pokemon; }
            set { SetProperty(ref pokemon, value); }
        }

        private Sprites sprites;

        public Sprites Sprites
        {
            get { return sprites; }
            set { SetProperty(ref sprites, value); }
        }

        private string sprite;

        public string Sprite
        {
            get { return sprite; }
            set { SetProperty(ref sprite, value); }
        }



        private string pokemonName;

        public string PokemonName
        {
            get { return pokemonName; }
            set { SetProperty(ref pokemonName, value); }
        }

        private int pokemonID;

        public int PokemonID
        {
            get { return pokemonID; }
            set { SetProperty(ref pokemonID,value); }
        }


        private IEnumerable<string> allPokemonNames;

        public IEnumerable<string> AllPokemonNames
        {
            get { return allPokemonNames; }
            set { SetProperty(ref allPokemonNames, value); }
        }




    }
}
