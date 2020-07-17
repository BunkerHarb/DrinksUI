using DrinksUI.Dtos.implementations;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Data.Models
{
    public class AddieModel
    {
        public int Id { get; set; }
        public IngredientModel Ingredient { get; set; }
        public int Amount { get; set; }

        public IAddie GetDto => new AddieDto(Id, Ingredient.GetDto, Amount);
    }
}