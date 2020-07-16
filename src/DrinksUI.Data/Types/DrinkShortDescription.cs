using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Data.Types
{
    public class DrinkShortDescription : IDrinkShortDescription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}