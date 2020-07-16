using System.Collections.Generic;
using System.Linq;
using DrinksUI.Data;
using DrinksUI.Data.Models;
using DrinksUI.Dtos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DrinksUI.Test.Data
{
    public class DbContext
    {
        private DrinkContext _context;
        private SqliteConnection _connection;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<DrinkContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new DrinkContext(options);
            _context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Close();
        }

        [Test]
        public void CanInsertAndRetrieveIngredients()
        {
            var ingredients = new List<IngredientModel>(){
                new IngredientModel(){Type = "Vodka", AddiType = AddiType.PushDosed, Unit = Unit.CL},
                new IngredientModel(){Type = "Lemon Slice", AddiType = AddiType.Extra, Unit = Unit.Pcs}
            };

            _context.AddRange(ingredients);
            _context.SaveChanges();

            var vodka = _context.Ingredients.FirstOrDefault(x => x.Type == "Vodka");
            Assert.That(vodka, Is.Not.Null);
            Assert.That(vodka.AddiType, Is.Not.Null);
            Assert.That(vodka.Unit, Is.Not.Null);
        }

        [Test]
        public void CanInsertAndRetrieveDrink()
        {
            var ingredients = new List<IngredientModel>(){
                new IngredientModel(){Type = "Vodka", AddiType = AddiType.PushDosed, Unit = Unit.CL},
                new IngredientModel(){Type = "Lemon Slice", AddiType = AddiType.Extra, Unit = Unit.Pcs}
            };

            _context.AddRange(ingredients);
            _context.SaveChanges();

            _context.Add(new DrinkModel()
            {
                Name = "screwDriver",
                description = "Something That ReSpeller Won't hate",
                Addis = new List<AddiModel>()
                {
                    new AddiModel() {Ingredient = ingredients[0], Amount = 2},
                    new AddiModel() {Ingredient = ingredients[1], Amount = 14}
                }
            });

            _context.SaveChanges();

            var drink = _context.Drinks.FirstOrDefault();
            Assert.That(drink, Is.Not.Null);
            Assert.That(drink.description, Is.Not.Null);
            Assert.That(drink.Addis, Has.Count.EqualTo(2));
        }
    }
}