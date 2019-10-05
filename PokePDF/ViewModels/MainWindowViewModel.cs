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
using System.Windows;
using System.Windows.Input;

namespace PokePDF.ViewModels
{
    public class MainWindowViewModel : BindableDataErrorInfoBase
    {
        private readonly PokeInformationService _pokeService;
        private readonly PrintingService _printingService;

        public ICommand PrintAllPokemon { get; }
        public ICommand SearchPokemon { get; }
        public ICommand SortByTypeCommand { get; }

        public ICommand PrintSelectedPokemonCommand { get; set; }


        public MainWindowViewModel()
        {

            _pokeService = new PokeInformationService();
            _printingService = new PrintingService();
            SearchPokemon = new AwaitableDelegateCommand(SearchPokemonAsync);
            SortByTypeCommand = new AwaitableDelegateCommand(SortByType);
            PrintSelectedPokemonCommand = new AwaitableDelegateCommand(PrintSelectedPokemon);
            PrintAllPokemonAsync();
           
        }

        public async Task PrintSelectedPokemon()
        {
            if (PokemonIsValid)
            {
                _printingService.Print(await _pokeService.GetPokemonInfoAsync(PokemonName));
            }
            else
            {

            }
        }

        public async Task PrintAllPokemonAsync()
        {
            var pokemon = await _pokeService.GetAllPokemonNamesAsync();
            Pokemon = await _pokeService.GetPokemonInfoAsync(PokemonName);
            AllPokemonNames = pokemon;
            SortedPokemonNames = pokemon;
           // _printingService.Print(await _pokeService.GetPokemonInfoAsync("pikachu"));
        }
        public async Task SearchPokemonAsync()
        {
            var pokemonInfo = await _pokeService.GetPokemonInfoAsync(PokemonName);
            Pokemon = pokemonInfo;
        }
        public async Task SortByType()
        {
            var pokemonInfo = await _pokeService.GetPokemonByType(PokemonTypeProperty);
            SortedPokemonNames = _pokeService.PokemonEnumerabletoStringConverter(pokemonInfo);
        }

        private string pokemonNameError;
        public string PokemonNameError
        {
            get { return pokemonNameError; }
            set
            {
                SetProperty(ref pokemonNameError, value);
                ErrorDictionary[nameof(PokemonName)] = value;
                PokemonNameErrorVisibility = value.IsNullOrWhiteSpace() ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private Visibility pokemonNameErrorVisibility;
        public Visibility PokemonNameErrorVisibility
        {
            get { return pokemonNameErrorVisibility; }
            set
            {
                SetProperty(ref pokemonNameErrorVisibility, value);
                RaisePropertyChanged(nameof(PokemonIsValid));
            }
        }


        private string pokemonTypeProperty;
        public string PokemonTypeProperty
        {
            get { return pokemonTypeProperty; }
            set { SetProperty(ref pokemonTypeProperty , value); }
        }

        public List<string> ListOfPokemonType
        {
            get { return PokemonTypeList.PokemonTypeNames; }
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

        public bool PokemonIsValid
        {
            get { return pokemonNameErrorVisibility == Visibility.Collapsed; }
        }


        private string pokemonName;
        public string PokemonName
        {
            get { return pokemonName; }
            set
            {
                pokemonName = value.ToLower();
                if (_pokeService.IsPokemonNameValid(pokemonName, AllPokemonNames) == false)
                {
                    PokemonNameError = "This pokemon does not exist, yet...";
                }
                else
                {
                    PokemonNameError = null;
                }
                    SetProperty(ref pokemonName, pokemonName);
            }
        }

        private int pokemonID;
        public int PokemonID
        {
            get { return pokemonID; }
            set { SetProperty(ref pokemonID,value); }
        }

        private IEnumerable<string> sortedPokemonNames;
        public IEnumerable<string> SortedPokemonNames
        {
            get { return sortedPokemonNames; }
            set { SetProperty(ref sortedPokemonNames, value); }
        }

        private IEnumerable<string> allPokemonNames;
        public IEnumerable<string> AllPokemonNames
        {
            get { return allPokemonNames; }
            set { SetProperty(ref allPokemonNames, value); }
        }
    }
    public static class DemoExtensionMethods
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
