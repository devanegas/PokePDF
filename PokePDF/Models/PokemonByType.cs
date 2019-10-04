using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokePDF.Models
{
    public class PokemonByType
    {
        [JsonProperty("name")]
        public string TypeName { get; set; }
        [JsonProperty("pokemon")]
        public List<PokemonNameByType> PokemonNames { get; set; }
    }

    public class PokemonNameByType
    {
        [JsonProperty("pokemon")]
        public YetAnotherName Name { get; set; }
    }

    public class YetAnotherName
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
