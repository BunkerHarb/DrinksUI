using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Web.Entities
{
    public class DrinkShortDescription : IDrinkShortDescription
    {
        public int Id { get; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DrinkShortDescription(IDrinkShortDescription description)
        {
            Id = description.Id;
            Name = description.Name;
            ImageUrl = description.ImageUrl;
        }
    }
}