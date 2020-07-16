using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksUI.Data.Types;
using DrinksUI.Dtos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrinksUI.Data.Services
{
    public class DrinkService
    {
        private readonly DrinkContext _drinkContext;

        public DrinkService(DrinkContext drinkContext)
        {
            _drinkContext = drinkContext;
            _drinkContext.Database.EnsureCreated();
        }

        public async Task<Drink> GetDrink(int id)
        {
            var result = await _drinkContext.Drinks
                                    .Include(Drink => Drink.Addies)
                                    .ThenInclude(addie => addie.Ingredient)
                                    .Where(y => y.Id == id)
                                    .FirstOrDefaultAsync();
            
            return Drink.Create(result);
        }

        public Task<IEnumerable<IDrinkShortDescription>> GetShortDescriptions()
        {
            IEnumerable<IDrinkShortDescription> result = _drinkContext.Drinks.Select(x => new DrinkShortDescription(){Name = x.Name, id = x.Id, ImageUrl = x.ImageUrl}).AsEnumerable();
            return Task.FromResult(result);
        }
    }
}