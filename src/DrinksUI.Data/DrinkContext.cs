using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DrinksUI.Data.Models;


namespace DrinksUI.Data
{
    public class DrinkContext : DbContext
    {
        public DbSet<DrinkModel> Drinks { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }

        public DrinkContext(DbContextOptions<DrinkContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=../testDb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)    
        {
            builder.Entity<DrinkModel>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<IngredientModel>()
                .HasIndex(x => x.Type)
                .IsUnique();
        }

        public async Task<string> AddMockData()
        {
            var drinks = Drinks.CountAsync();
            var ingredients = Ingredients.CountAsync();

            if ((await drinks + await ingredients) == 0)
            {
                try
                {
                    var mockData = new MockDataBuilder();
                    mockData.SubmitThatShit(this);
                }
                catch
                {
                    return "Failed at creating mock data";
                }
                return "Added mock data";
            }

            return "Already got data make sure the database is empty before you add";
        }

        public async Task<string> DeleteMockData()
        {
            try
            {
                await Database.EnsureDeletedAsync();
                await Database.EnsureCreatedAsync();
            }
            catch 
            {
                return "Couldn't delete data";
            }

            return "Deleted Data";
        }
    }
}