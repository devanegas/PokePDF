using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokePDF.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }
        [JsonProperty("stats")]
        public List<Stats> Stats { get; set; }
        [JsonProperty("types")]
        public List<PokemonTypes> PokemonTypes { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }

        public string GetName() { return Name; }
    }

    public class Sprites
    {
        [JsonProperty("back_default")]
        public string Back_default { get; set; }
        [JsonProperty("back_shiny")]
        public string Back_shiny { get; set; }
        [JsonProperty("front_default")]
        public string Front_default { get; set; }
        [JsonProperty("front_shiny")]
        public string Front_shiny { get; set; }
        [JsonProperty("back_female")]
        public string Back_female { get; set; }
        [JsonProperty("back_shiny_female")]
        public string Back_shiny_female { get; set; }
        [JsonProperty("front_female")]
        public string Front_female { get; set; }
        [JsonProperty("front_shiny_female")]
        public string Front_shiny_female { get; set; }
    }

    public class Stats
    {
        [JsonProperty("base_stat")]
        public int Base_stat { get; set; }
        [JsonProperty("stat")]
        public Stat Stat { get; set; }
    }

    public class Stat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class PokemonTypes
    {
        [JsonProperty("type")]
        public PokemonType PokemonType { get; set; }
        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public class PokemonType
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
