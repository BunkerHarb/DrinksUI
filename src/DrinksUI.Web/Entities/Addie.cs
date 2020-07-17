using DrinksUI.Dtos;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Web.Entities
{
    public class Addie : IAddie
    {
        public int Id { get; }
        public IIngredient Ingredient { get; set; }
        public int Amount { get; set; }
        public string Name => Ingredient.ToString();

        public string Display => $"{Amount} {Ingredient.Unit} - {Ingredient.Type}";
        public string UnitAndName => $"{Ingredient.Unit} - {Ingredient.Type}";
        public bool IsLiquid => Ingredient.AddieType != AddieType.Extra;

        public Addie(IAddie addie)
        {
            Id = addie.Id;
            Ingredient = addie.Ingredient; 
            Amount = addie.Amount;
        }
    }
}