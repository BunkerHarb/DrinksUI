using DrinksUI.Dtos;

namespace DrinksUI.Data.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public AddieType AddieType { get; set; }
        public Unit Unit { get; set; }
    }
}