using DrinksUI.Dtos;
using System.Collections.Generic;
using DrinksUI.Data.Models;
using System.Linq;

namespace DrinksUI.Data.Types
{
    public class Drink
    {
        public List<Addie> Addies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl {get; set;}

        public static Drink Create(DrinkModel model) => new Drink(){Addies = model.Addies.Select(Addie.Create).ToList(), Name = model.Name, Description = model.Description, ImageUrl = model.ImageUrl ?? ""};
    }
}