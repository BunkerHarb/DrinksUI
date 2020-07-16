namespace DrinksUI.Dtos.Interfaces
{
    public interface IIngredient
    {
        int Id { get; }
        string Type { get; set; }
        AddieType AddieType { get; set; }
        Unit Unit { get; set; }
    }
}