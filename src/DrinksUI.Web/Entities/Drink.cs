using System.Collections.Generic;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Web.Entities
{
    public class Drink : IDrink
    {
        public int Id { get; }
        public List<IAddie> Addies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl {get; set;}

        public Drink(IDrink drink)
        {
            Id = drink.Id;
            Addies = drink.Addies;
            Name = drink.Name;
            Description = drink.Description;
            ImageUrl = drink.ImageUrl;
        }
    }
}