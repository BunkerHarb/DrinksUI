using System.Collections.Generic;

namespace DrinksUI.Data.Models
{
    public class DrinkModel
    {
        public int Id { get; set; }
        public List<AddieModel> Addies { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl {get; set;}
    }
}