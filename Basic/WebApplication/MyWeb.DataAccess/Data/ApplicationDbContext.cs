using Microsoft.EntityFrameworkCore;
using MyWeb.Models;

namespace MyWeb.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //create table for database and call migration in Nuget
        public DbSet<Category>Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //clone database
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CaterogyName = "Food and beverage", DisplayOrder = 1 },
                new Category { CategoryID = 2, CaterogyName = "Fast food", DisplayOrder = 2 },
                new Category { CategoryID = 3, CaterogyName = "Spicy food", DisplayOrder = 3 }
                );
        }

    }
}
