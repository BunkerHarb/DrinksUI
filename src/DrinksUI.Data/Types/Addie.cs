using DrinksUI.Dtos;
using DrinksUI.Data.Models;

namespace DrinksUI.Data.Types
{
    public class Addie
    {
        public Ingredient Ingredient;
        public int Amount;
        public string Name => Ingredient.ToString();

        public string Display => $"{Amount} {Ingredient.Unit} - {Ingredient.Type}";
        public string UnitAndName => $"{Ingredient.Unit} - {Ingredient.Type}";
        public bool IsLiquid => Ingredient.AddieType != AddieType.Extra;

        public static Addie Create(IAddieModel model) => new Addie(){Ingredient = Ingredient.Create(model.Ingredient), Amount = model.Amount};
    }
}