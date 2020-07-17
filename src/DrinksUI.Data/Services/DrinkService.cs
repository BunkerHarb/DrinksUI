using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksUI.Dtos.implementations;
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

        public async Task<IDrink> GetDrink(int id)
        {
            var result = await _drinkContext.Drinks
                                    .Include(drink => drink.Addies)
                                    .ThenInclude(addie => addie.Ingredient)
                                    .Where(y => y.Id == id)
                                    .FirstOrDefaultAsync();
            
            return result.GetDto;
        }

        public Task<IEnumerable<IDrinkShortDescription>> GetShortDescriptions()
        {
            IEnumerable<IDrinkShortDescription> result = _drinkContext.Drinks.Select(x => new DrinkShortDescriptionDto(x.Id, x.Name, x.ImageUrl)).AsEnumerable();
            return Task.FromResult(result);
        }

        public async Task<string> AddMockData()
        {

            return await _drinkContext.AddMockData();
        }

        public async Task<string> DeleteMockData()
        { 
            return await _drinkContext.DeleteMockData();
        }
    }
}