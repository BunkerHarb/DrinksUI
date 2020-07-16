namespace DrinksUI.Dtos.Interfaces
{
    public interface IAddie
    {
        int Id { get; }
        IIngredient Ingredient { get; set; }
        int Amount { get; set; }
    }
}