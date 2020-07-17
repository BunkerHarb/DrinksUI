
using System.Linq;
using DrinksUI.Data;
using DrinksUI.Data.Services;
using DrinksUI.Dtos.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
// ReSharper disable SuggestVarOrType_SimpleTypes

namespace DrinksUI.Test.service
{
    [TestFixture]
    public class DrinkServiceTest
    {
        private DrinkService _sut;
        private SqliteConnection _connection;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<DrinkContext>()
                .UseSqlite(_connection)
                .Options;

            var context = new DrinkContext(options);
            context.Database.EnsureCreated();

            _sut = new DrinkService(context);

            _sut.AddMockData();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _connection.Close();
        }

        [Test]
        public void GetDrink()
        {
            var task =  _sut.GetDrink(1);
            IDrink drink = task.Result;

            Assert.That(drink, Is.Not.Null);
            Assert.That(drink.Name, Is.EqualTo("Død"));
            Assert.That(drink.Addies, Has.Count.EqualTo(3));
        }

        [Test]
        public void GetShortlist()
        {
            var task = _sut.GetShortDescriptions();
            IDrinkShortDescription[] drink = task.Result.ToArray();

            Assert.That(drink, Is.Not.Null);
            Assert.That(drink.Length, Is.EqualTo(3));
        }
    }
}