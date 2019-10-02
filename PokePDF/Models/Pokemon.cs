using System;
using System.Collections.Generic;
using System.Text;

namespace PokePDF.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sprites> Sprites { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Types> Types { get; set; }
        public int Weight { get; set; }


    }

    public class Sprites
    {
        public string Back_default { get; set; }
        public string Back_shiny { get; set; }
        public string Front_default { get; set; }
        public string Front_shiny { get; set; }
        public string Back_default_female { get; set; }
        public string Back_shiny_female { get; set; }
        public string Front_default_female { get; set; }
        public string Front_shiny_female { get; set; }
    }

    public class Stats
    {
        public int Base_stat { get; set; }
        public Stat Stat { get; set; }
    }

    public class Stat
    {
        public string Name { get; set; }
    }

    public class Types
    {
        public Type Type { get; set; }
    }

    public class Type
    {
        public int Slot { get; set; }
        public string Name { get; set; }
    }
}
