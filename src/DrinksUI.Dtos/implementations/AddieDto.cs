using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Dtos.implementations
{
    public class AddieDto : IAddie
    {
        public int Id { get; }
        public IIngredient Ingredient { get; set; }
        public int Amount { get; set; }

        public AddieDto(int id, IIngredient ingredient, int amount)
        {
            Id = id;
            Ingredient = ingredient;
            Amount = amount;
        }
    }
}