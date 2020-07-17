using Microsoft.EntityFrameworkCore;
using DrinksUI.Data.Models;
using DrinksUI.Dtos;


namespace DrinksUI.Data
{
    public class DrinkContext : DbContext
    {
        public DbContext Instance => this;
        public DbSet<DrinkModel> Drinks { get; set; }
        public DbSet<AddieModel> Addies { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }

        public DrinkContext(DbContextOptions<DrinkContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=../testdb.db");
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
    }
}