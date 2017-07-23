using System;
using System.Collections.Generic;
using System.IO;
using recipeParser.Classes;

namespace recipeParser
{
    public class printFunctions
    {
		public static void printQuantity(List<Recipe> newRecipeList)
		{
			foreach (Recipe recipe in newRecipeList)
			{
				foreach (newIngredient newIngredient in recipe.NewIngredientList)
				{

					Console.WriteLine("Quantity: " + newIngredient.Quantity + '\t' + '\t' + '|' + newIngredient.FullList);
				}
			}
		}

		public static void printAndCreateUnitList(List<Recipe> newRecipeList, List<resultPiece> unitList)
		{
			foreach (Recipe recipe in newRecipeList)
			{

				foreach (newIngredient newIngredient in recipe.NewIngredientList)
				{
					Console.WriteLine("Unit: " + newIngredient.Unit + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);

					bool stop = false;
					foreach (resultPiece unit in unitList)
					{
						if (String.Compare(unit.Name, newIngredient.Unit) == 0)
						{
							unit.Count++;
							stop = true;
							break;
						}
					}

					if (stop == false)
					{
						resultPiece unit = new resultPiece(newIngredient.Unit);
						unit.Count++;
						unitList.Add(unit);

					}



				}

			}

		}
		public static void printIngredients(List<Recipe> newRecipeList, List<resultPiece> ingredientList)
		{



			foreach (Recipe recipe in newRecipeList)
			{
				foreach (newIngredient newIngredient in recipe.NewIngredientList)
				{
					Console.WriteLine("Ingredient: " + newIngredient.Name + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);

					bool stop = false;
					foreach (resultPiece ingredient in ingredientList)
					{
						if (String.Compare(ingredient.Name, newIngredient.Name) == 0)
						{
							ingredient.Count++;
							stop = true;
							break;
						}
					}

					if (stop == false)
					{
						resultPiece ingredient = new resultPiece(newIngredient.Name);
						ingredient.Count++;
						ingredientList.Add(ingredient);

					}

				}


			}

		}

		public static void printPreparation(List<Recipe> newRecipeList)
		{
			foreach (Recipe recipe in newRecipeList)
			{
				foreach (newIngredient newIngredient in recipe.NewIngredientList)
				{
					Console.WriteLine("Preparation: " + newIngredient.Preparation + '\t' + '\t' + '\t' + '|' + newIngredient.FullList);
				}
			}
		}
	}


}
