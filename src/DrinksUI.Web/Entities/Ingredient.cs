using DrinksUI.Dtos;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Web.Entities
{
    public class Ingredient : IIngredient
    {
        public int Id { get; }
        public string Type { get; set; }
        public AddieType AddieType { get; set; }
        public Unit Unit { get; set; }

        public Ingredient(IIngredient ingredient)
        {
            Id = ingredient.Id;
            Type = ingredient.Type;
            AddieType = ingredient.AddieType;
            Unit = ingredient.Unit;
        }
    }
}