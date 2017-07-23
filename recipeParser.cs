using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using recipeParser.Classes;



namespace recipeParser
{

    public class MainClass
    {
        public static string fileRoot = "/Users/scottkrepsky/Documents/CS Classes/CS-564/Final Project/Recipe Parser";

        public static AcceptableUnits acceptableUnitsObj;

        public static void Main(string[] args)
        {

            acceptableUnitsObj = new AcceptableUnits();

            List<Recipe> newRecipeList = new List<Recipe>();
            readFromFile(newRecipeList, 1075);

			//printQuantity(newRecipeList);

			//Create Unit List for analysis
			//List<resultPiece> unitList = new List<resultPiece>();
			//printAndCreateUnitList(newRecipeList, unitList);

			//List<resultPiece> ingredientList = new List<resultPiece>();
			//printIngredients(newRecipeList, ingredientList);
			//printPreparation(newRecipeList);

			/*
	        unitList.Sort();

			foreach (resultPiece unit in unitList)
			{
				Console.WriteLine(unit.Name + ' ' + unit.Count);
			}

            */
			/*
            ingredientList.Sort();
            foreach (resultPiece ingredient in ingredientList)
            {
                Console.WriteLine(ingredient.Name + '~' + ingredient.Count);
            }
            */

			// Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(fileRoot, "IngredientFile.txt"));

            foreach (Recipe recipe in newRecipeList){

                foreach (newIngredient ingredient in recipe.NewIngredientList){

                    file.WriteLine(ingredient.Quantity + "|" + ingredient.Unit +
                                  "|" + ingredient.Name + "|" +
                                  ingredient.Preparation);

                }


				

				



            }

            file.Close();

        }

        public static string getAmount(string ingredient, ref string remainingIngredient)
        {
            if (remainingIngredient.Contains(' '))
            {

                remainingIngredient = ingredient.Substring(ingredient.IndexOf(' '));
                remainingIngredient = remainingIngredient.Trim(' ');

            }
            return ingredient.Split(' ')[0];
        }

        public static string getUnit(ref string amount, ref string remainingIngredient)
        {
            

            //quit if this recipe contains no more words
            if (!remainingIngredient.Contains(' '))
            {
                return null;
            }

            string unit = remainingIngredient.Split(' ')[0];

            
            //if the unit begins with a digit then we know that it is the amount continuing (e.g. 1 1/2)
            if (unit.ElementAt(0).ToString().Any(char.IsDigit) 
                && unit.Length > 0                
                && string.Compare(unit.ElementAtOrDefault(1).ToString(), "/", StringComparison.CurrentCulture) == 0)
            {
                amount = amount + ' ' + unit; //append unit to amount

                //Get remaining part of string
                remainingIngredient = remainingIngredient.Substring(remainingIngredient.IndexOf(' '));
                remainingIngredient = remainingIngredient.Trim(' ');
                unit = remainingIngredient.Split(' ')[0]; //update unit to next work
            }

            //check to see if the unit is one of the ones we know about
            if (acceptableUnitsObj.AcceptableUnitList.Contains(unit)){
				remainingIngredient = remainingIngredient.Substring(remainingIngredient.IndexOf(' '));
				remainingIngredient = remainingIngredient.Trim();
            } 
            else 
            {
                unit = null;
            }

            return unit;

        }

        public static string getIngredientAndPreparation(ref string remainingIngredient, ref string preparation)
        {
            string actualIngredient = null;

			if (remainingIngredient.Contains(','))
			{
				actualIngredient = remainingIngredient.Split(',')[0];
				preparation = remainingIngredient.Substring(remainingIngredient.IndexOf(','));
				preparation = preparation.Trim(',');
				preparation = preparation.Trim(' ');
			}
			else
			{
				actualIngredient = remainingIngredient;

			}


            return actualIngredient;
        }


        public static List<newIngredient> parseIngredients(Recipe recipe)
        {

            List<newIngredient> newIngredientList = new List<newIngredient>();
            foreach (string ingredient in recipe.Ingredients){

                //if the first character is not a digit then we'll make the full line an ingredient
                //TODO add a function inside this instead to also handle non digit quantities?
                //Structure: [ingredient]
                if (!ingredient.ElementAt(0).ToString().Any(char.IsDigit))
                {
                    createNewIngredient(ref newIngredientList, null, null, ingredient, null);
                    continue;

                }

                //[Amount] [Unit] [Ingredient],[Preparation]
                //First split out the amount
                string remainingIngredient = ingredient;
                string amount = getAmount(ingredient, ref remainingIngredient);


				//Get the next piece, the unit
                string unit = getUnit(ref amount, ref remainingIngredient);


				//Get remaining part of string
				string preparation = null;

                string actualIngredient = getIngredientAndPreparation(ref remainingIngredient, ref preparation);

                createNewIngredient(ref newIngredientList, amount, unit, actualIngredient, preparation);


            }

            return newIngredientList;

        }

        public static void createNewIngredient(ref List<newIngredient> newIngredientList, string amount, string unit, string actualIngredient, string preparation)
        {

			newIngredient newIngredientToAdd = new newIngredient();
			newIngredientToAdd.Name = actualIngredient;
			newIngredientToAdd.Preparation = preparation;
			newIngredientToAdd.Quantity = amount;
			newIngredientToAdd.Unit = unit;

			newIngredientList.Add(newIngredientToAdd);
        }

        public static void readFromFile(List<Recipe> newRecipeList, int numRecipes)
        {
               using (StreamReader r = new StreamReader("/Users/scottkrepsky/Documents/CS Classes/CS-564/Final Project/Recipe Parser/full_format_recipes.json"))
            {



                string data = r.ReadToEnd();
                //Recipe recipe = JsonConvert.DeserializeObject<Recipe>(data);
                List<Recipe> recipeList = JsonConvert.DeserializeObject<List<Recipe>>(data);

                foreach (Recipe recipe in recipeList)
                {
                    //Parse out ingredients
                    List<newIngredient> newIngredientList = parseIngredients(recipe);
                    recipe.NewIngredientList = newIngredientList;


                    newRecipeList.Add(recipe);


                    if (newRecipeList.Count >= numRecipes){
                        break;
                    }


                }

            }
        }

	}
}

