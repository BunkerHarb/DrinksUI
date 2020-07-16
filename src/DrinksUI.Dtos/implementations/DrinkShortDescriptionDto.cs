using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Dtos.implementations
{
    public class DrinkShortDescriptionDto :IDrinkShortDescription
    {
        public int Id { get; }
        public string Name { get; }
        public string ImageUrl { get; }

        public DrinkShortDescriptionDto(int id, string name,string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}