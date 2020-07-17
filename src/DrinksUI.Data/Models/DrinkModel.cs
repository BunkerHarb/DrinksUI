using System.Collections.Generic;
using System.Linq;
using DrinksUI.Dtos.implementations;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Data.Models
{
    public class DrinkModel
    {
        public int Id { get; set; }
        public List<AddieModel> Addies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl {get; set;}

        public IDrink GetDto => new DrinkDto(Id, Name, Description, ImageUrl, Addies.Select(addie => addie.GetDto).ToArray());
    }
}