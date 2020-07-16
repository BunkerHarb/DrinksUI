using System.Collections.Generic;

namespace DrinksUI.Dtos.Interfaces
{
    public interface IDrink
    {
        int Id { get; }
        List<IAddie> Addies { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
    }
}