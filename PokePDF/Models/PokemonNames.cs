using System;
using System.Collections.Generic;
using System.Text;

namespace PokePDF.Models
{
    public class PokemonNames
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string Name { get; set; }
    }
}
