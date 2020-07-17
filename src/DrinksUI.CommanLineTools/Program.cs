using System;
using System.Linq;
using DrinksUI.Data;
using Microsoft.EntityFrameworkCore;

namespace DrinksUI.CommandLineTools
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Create DB");
            var options = new DbContextOptionsBuilder<DrinkContext>().Options;
            var drinkContext = new DrinkContext(options);
            drinkContext.Database.EnsureCreated();

            var mockDataBuilder = new MockDataBuilder();

            Console.WriteLine("Ready to insert Stuff");
            mockDataBuilder.SubmitThatShit(drinkContext);
            Console.WriteLine("inserted stuff");

            var test = drinkContext.Drinks.Include(x => x.Addies).ThenInclude(addie => addie.Ingredient).FirstOrDefault(i => i.Id == 1) ?? throw new NullReferenceException("Didn't get shit");
            Console.WriteLine($"got: {test.Name}");
        }
    }
}
