using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcArrayDataBinding.Models
{
    public class ColorsModel
    {
        public SelectList Colors
        {
            get
            {
                // Getting a list of Colors from the Colors enum
                List<Color> colors = ((IEnumerable<Colors>)Enum.GetValues(typeof(Colors))).
                    Select(c => new Color() { Name = c.ToString(), Value = (int)c }).ToList();

                // Returning a SelectList to be used on the View side
                return new SelectList(colors, "Value", "Name");
            }
        }
    }

    public class Color
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public enum Colors
    {
        Orange = 1,
        Red = 2,
        Green = 3,
        Blue = 4,
        Yellow = 5,
        Black = 6,
        White = 7,
        Pink = 8,
        Brown = 9,
        Gray = 10
    }
}