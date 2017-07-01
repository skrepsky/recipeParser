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
public class Recipe
    {
        [JsonProperty("directions")]
        public List<string> Directions
        {
            get; set;
        }
        [JsonProperty("fat")]
        public decimal? Fat
        {
            get; set;
        }
        [JsonProperty("date")]
        public string Date
        {
            get; set;
        }
        [JsonProperty("categories")]
        public List<string> Categories
        {
            get; set;
        }
        [JsonProperty("calories")]
        public decimal? Calories
        {
            get; set;
        }
        [JsonProperty("desc")]
        public string Description
        {
            get; set;
        }
        [JsonProperty("protein")]
        public decimal? Protein
        {
            get; set;
        }
        [JsonProperty("rating")]
        public decimal? Rating
        {
            get; set;
        }
        [JsonProperty("title")]
        public string Title
        {
            get; set;
        }
        [JsonProperty("ingredients")]
        public List<string> Ingredients
        {
            get; set;
        }
        [JsonProperty("newIngredientList")]
        public List<newIngredient> NewIngredientList
        {
            get; set;
        }
        [JsonProperty("sodium")]
        public decimal? Sodium
        {
            get; set;
        }


    }
}