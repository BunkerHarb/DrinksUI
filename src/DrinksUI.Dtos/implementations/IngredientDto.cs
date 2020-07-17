using DrinksUI.Dtos.Interfaces;

namespace DrinksUI.Dtos.implementations
{
    public class IngredientDto : IIngredient
    {
        public int Id { get; }
        public string Type { get; set; }
        public AddieType AddieType { get; set; }
        public Unit Unit { get; set; }

        public IngredientDto(int id, string type, AddieType addieType, Unit unit)
        {
            Id = id;
            Type = type;
            AddieType = addieType;
            Unit = unit;
        }
    }
}