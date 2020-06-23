using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Pokemon.Models
{

    public class Pokemon
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("number")]
        public string number { get; set; }
        [JsonProperty("supertype")]
        public string supertype { get; set; }
        [JsonProperty("imageUrl")]
        public string imageUrl { get; set; }
        [JsonProperty("subtype")]
        public string subtype { get; set; }
        [JsonProperty("rarity")]
        public string rarity { get; set; }
    }
    public class RootObject
    {
        public List<Pokemon> cards { get; set; }
    }
}