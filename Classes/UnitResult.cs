using System; using System.Collections.Generic; using System.IO; using System.Linq; using System.Text; using System.Net; using Newtonsoft.Json; using Newtonsoft.Json.Linq; using System.Text.RegularExpressions;  namespace recipeParser { 
public class UnitResult : IComparable<UnitResult>     {         public UnitResult(string name){             this.Name = name;             this.Count = 0;           }           public string Name         { get; set;}          public int Count
	{ get; set;}

        public int CompareTo(UnitResult other)
        {
            if (other.Count > this.Count)
            {                 return -1;             }             else if (other.Count == this.Count)
            {                 return 0;             }             else return 1;
        }     } }