using DrinksUI.Dtos;
using DrinksUI.Dtos.implementations;
using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Data.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public AddieType AddieType { get; set; }
        public Unit Unit { get; set; }

        public IIngredient GetDto => new IngredientDto(Id, Type, AddieType, Unit); 
    }
}