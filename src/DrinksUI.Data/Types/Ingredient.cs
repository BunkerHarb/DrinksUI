using DrinksUI.Dtos;
using DrinksUI.Data.Models;

namespace DrinksUI.Data.Types
{
    public class Ingredient
    {
        public string Type;
        public AddieType AddieType;
        public Unit Unit;

        public static Ingredient Create(IngredientModel model) => new Ingredient(){Type = model.Type, AddieType = model.AddieType, Unit = model.Unit};
    }
}