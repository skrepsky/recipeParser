using System;
using System.Collections.Generic;

namespace recipeParser.Classes
{
    public class AcceptableUnits
    {

        public AcceptableUnits()
        {

            AcceptableUnitList = new List<string>();


            AcceptableUnitList.Add("teaspoon");
            AcceptableUnitList.Add("teaspoons");
            AcceptableUnitList.Add("tsp");

            AcceptableUnitList.Add("tablespoon");
            AcceptableUnitList.Add("tablespoons");
            AcceptableUnitList.Add("tbsp");

            AcceptableUnitList.Add("cup");
            AcceptableUnitList.Add("cups");

            AcceptableUnitList.Add("pound");
            AcceptableUnitList.Add("pounds");
            AcceptableUnitList.Add("lb");


            AcceptableUnitList.Add("pint");
            AcceptableUnitList.Add("pints");

            AcceptableUnitList.Add("ounce");
            AcceptableUnitList.Add("ounces");
            AcceptableUnitList.Add("oz");

            AcceptableUnitList.Add("quart");
            AcceptableUnitList.Add("quarts");
            AcceptableUnitList.Add("qt");

            AcceptableUnitList.Add("clove");
            AcceptableUnitList.Add("cloves");

            AcceptableUnitList.Add("slice");
            AcceptableUnitList.Add("slices");

            AcceptableUnitList.Add("sprig");
            AcceptableUnitList.Add("sprigs");

            AcceptableUnitList.Add("stalk");
            AcceptableUnitList.Add("stalks");

            AcceptableUnitList.Add("sheet");
            AcceptableUnitList.Add("sheets");

            AcceptableUnitList.Add("head");
            AcceptableUnitList.Add("heads");

            AcceptableUnitList.Add("can");
            AcceptableUnitList.Add("cans");

            AcceptableUnitList.Add("jar");
            AcceptableUnitList.Add("jars");

            AcceptableUnitList.Add("gram");
            AcceptableUnitList.Add("grams");
            AcceptableUnitList.Add("g");

            AcceptableUnitList.Add("liter");
            AcceptableUnitList.Add("litre");
            AcceptableUnitList.Add("liters");
            AcceptableUnitList.Add("litres");
            AcceptableUnitList.Add("l");

            AcceptableUnitList.Add("milliliter");
            AcceptableUnitList.Add("millilitre");
            AcceptableUnitList.Add("milliliters");
            AcceptableUnitList.Add("millilitres");
            AcceptableUnitList.Add("mL");
            AcceptableUnitList.Add("ml");

            AcceptableUnitList.Add("bunch");

            AcceptableUnitList.Add("bottle");
            AcceptableUnitList.Add("bottles");

            AcceptableUnitList.Add("slab");
            AcceptableUnitList.Add("slabs");

            AcceptableUnitList.Add("envelope");
            AcceptableUnitList.Add("envelopes");

            AcceptableUnitList.Add("package");
            AcceptableUnitList.Add("packages");

            AcceptableUnitList.Add("stick");
            AcceptableUnitList.Add("sticks");

            AcceptableUnitList.Add("strip");
            AcceptableUnitList.Add("strips");

            AcceptableUnitList.Add("piece"); //TODO this would probably be followed by "of"
            AcceptableUnitList.Add("pieces");

            AcceptableUnitList.Add("basket");
            AcceptableUnitList.Add("baskets");

            AcceptableUnitList.Add("bag");
            AcceptableUnitList.Add("bags");
        }

        public List<string> AcceptableUnitList
        { get; set; }




    }
}
