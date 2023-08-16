using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace BlazorFullStack.Server.Data
{
	public class DataContext : DbContext
	{
        private readonly string _connectionString;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
		{
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>().HasData(
                 new Comic { Id = 1, Name = "Marvel" },
                 new Comic { Id = 2, Name = "DC" }
            );

            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                ComicId = 1,
            },

            new SuperHero
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                ComicId = 2,
            }
         
            );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DbSet<Comic> Comics { get; set; }

        
    }
}

