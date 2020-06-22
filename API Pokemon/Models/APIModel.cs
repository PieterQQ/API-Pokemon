using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Pokemon.Models
{
    public class APIModel
    {
    }
    public class Pokemon
    {
        public string Name { get; set; }
        public int id { get; set; }
        public string supertype { get; set; }
        public string subtype { get; set; }
        public string rarity { get; set; }
    }
    public class RootObject
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Pokemon> pokemons { get; set; }
    }
}