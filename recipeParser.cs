using System; using System.Collections.Generic; using System.IO; using System.Linq; using System.Text; using System.Net; using Newtonsoft.Json; using Newtonsoft.Json.Linq; using System.Text.RegularExpressions;  namespace recipeParser {      public class MainClass     {         public static void Main(string[] args)         {             /*using (StreamReader r = new StreamReader("/Users/scottkrepsky/Documents/CS Classes/CS-564/Final Project/JSON Parser/SingleRecipe.json"))             {             */             List<Recipe> newRecipeList = new List<Recipe>();             using (StreamReader r = new StreamReader("/Users/scottkrepsky/Documents/CS Classes/CS-564/Final Project/Recipe Parser/full_format_recipes.json"))             {                    string data = r.ReadToEnd();                 //Recipe recipe = JsonConvert.DeserializeObject<Recipe>(data);                 List<Recipe> recipeList = JsonConvert.DeserializeObject<List<Recipe>>(data);                  foreach (Recipe recipe in recipeList)                 {                     //Parse out ingredients                     List<newIngredient> newIngredientList = parseIngredients(recipe);                     recipe.NewIngredientList = newIngredientList;                       newRecipeList.Add(recipe);                       if (newRecipeList.Count > 50){                         break;                     }                  }              }  			foreach (Recipe recipe in newRecipeList) 			{ 				foreach (newIngredient newIngredient in recipe.NewIngredientList) 				{  					Console.WriteLine("Quantity: " + newIngredient.Quantity + '\t' + '\t' + '|' + newIngredient.FullList); 				} 			}


            //Create Unit List for analysis

            List<UnitResult> unitList = new List<UnitResult>();              foreach (Recipe recipe in newRecipeList)             {                  foreach (newIngredient newIngredient in recipe.NewIngredientList)                 {                     Console.WriteLine("Unit: " + newIngredient.Unit + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);                      bool stop = false;                     foreach (UnitResult unit in unitList){                         if(String.Compare(unit.Name, newIngredient.Unit) == 0){                             unit.Count++;                             stop = true;                             break;                         }                     }                      if (stop == false){                         UnitResult unit = new UnitResult(newIngredient.Unit);                         unit.Count++;                         unitList.Add(unit);                      }                    }              }                foreach (Recipe recipe in newRecipeList)             {                 foreach (newIngredient newIngredient in recipe.NewIngredientList)                 {                     Console.WriteLine("Ingredient: " + newIngredient.Name + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);                 }             }              foreach (Recipe recipe in newRecipeList)             {                 foreach (newIngredient newIngredient in recipe.NewIngredientList)                 {                     Console.WriteLine("Preparation: " + newIngredient.Preparation + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);                 }             }

			unitList.Sort();

			foreach (UnitResult unit in unitList)
			{
				Console.WriteLine(unit.Name + ' ' + unit.Count);
			}           }         public static List<newIngredient> parseIngredients(Recipe recipe)         {              List<newIngredient> newIngredientList = new List<newIngredient>();             foreach (string ingredient in recipe.Ingredients){   				//[Amount] [Unit] [Ingredient],[Preparation] 				//First split out the amount 				string amount = ingredient.Split(' ')[0];  				//Get remaining part of string 				string remainingIngredient = ingredient.Substring(ingredient.IndexOf(' ')); 				remainingIngredient = remainingIngredient.Trim(' ');  				//Get the next piece, the unit 				string unit = remainingIngredient.Split(' ')[0];                  //if the unit begins with a digit then we know that it is the amount continuing (e.g. 1 1/2)                 if (unit.Any(char.IsDigit)) 				{                     amount = amount + ' ' + unit; //append unit to amount  					//Get remaining part of string 					remainingIngredient = remainingIngredient.Substring(remainingIngredient.IndexOf(' ')); 					remainingIngredient = remainingIngredient.Trim(' ');                     unit = remainingIngredient.Split(' ')[0]; //update unit to next word. 				}                  //if it contains a space that means we have [amount] [unit] [ingredient]                 if (remainingIngredient.Contains(' '))                 {                     remainingIngredient = remainingIngredient.Substring(remainingIngredient.IndexOf(' '));                     remainingIngredient = remainingIngredient.Trim();                 }                 //if we don't have a space that means we have [amount] [ingredient, e.g. two eggs                 else                  {                     unit = null;                 }  				//Get remaining part of string 				string actualIngredient = null; 				string preparation = null; 				if (remainingIngredient.Contains(',')) 				{ 					actualIngredient = remainingIngredient.Split(',')[0]; 					preparation = remainingIngredient.Substring(remainingIngredient.IndexOf(',')); 					preparation = preparation.Trim(','); 					preparation = preparation.Trim(' '); 				} 				else 				{ 					actualIngredient = remainingIngredient;  				}                  newIngredient newIngredientToAdd = new newIngredient();                 newIngredientToAdd.Name = actualIngredient;                 newIngredientToAdd.Preparation = preparation;                 newIngredientToAdd.Quantity = amount;                 newIngredientToAdd.Unit = unit;                  newIngredientList.Add(newIngredientToAdd);               }              return newIngredientList;          }     } }  