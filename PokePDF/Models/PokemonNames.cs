using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokePDF.Models
{
    public class PokemonNames
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
