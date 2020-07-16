using System.Collections.Generic;
using System.Linq;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Dtos.implementations
{
    public class DrinkDto : IDrink
    {
        public int Id { get; }
        public List<IAddie> Addies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public DrinkDto(int id, string name, string description, string imageUrl, IEnumerable<IAddie> addies)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Addies = addies.ToList();
        }
    }
}