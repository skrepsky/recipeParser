using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace recipeParser
{ 
public class newIngredient
    {
        [JsonProperty("name")]
        public string Name
        { get; set;}

        [JsonProperty("quantity")]
        public string Quantity
        { get; set; }

        [JsonProperty("unit")]
        public string Unit
        { get; set; }

        [JsonProperty("preparation")]
        public string Preparation
        { get; set; }

        public string FullList
        { get{
               return Quantity + ' ' + Unit + ' ' + Name + ' ' + Preparation;
            }}
    }
}