using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //create table for database and call migration in Nuget
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Áo nam", DisplayOrder = 1 },
                new Category { CategoryID = 2, CategoryName = "Áo nữ", DisplayOrder = 2 },
                new Category { CategoryID = 3, CategoryName = "Quần nam", DisplayOrder = 3 },
                new Category { CategoryID = 4, CategoryName = "Quần nữ", DisplayOrder = 4 },
                new Category { CategoryID = 5, CategoryName = "Giày nam", DisplayOrder = 5 },
                new Category { CategoryID = 6, CategoryName = "Giày nữ", DisplayOrder = 6 }

            );

            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      ProductID = 1,
                      ProductName = "Áo T-Shirt Together",
                      Description = "Áo thun nam trắng",
                      ListPrice = 40,
                      Price = 40,
                      Price50 = 35,
                      Price100 = 30,
                      CategoryID = 1,
                      ImageUrl = ""
                  },
                  new Product
                  {
                      ProductID = 2,
                      ProductName = "Áo phông SandBoxWrangler",
                      Description = "Áo thun nam trắng",
                      ListPrice = 80,
                      Price = 80,
                      Price50 = 75,
                      Price100 = 70,
                      CategoryID = 1,
                      ImageUrl = ""
                  },
                  new Product
                  {
                      ProductID = 3,
                      ProductName = "Áo Polo Cotton",
                      Description = "Áo thun nam xanh",
                      ListPrice = 95,
                      Price = 95,
                      Price50 = 90,
                      Price100 = 85,
                      CategoryID = 1,
                      ImageUrl = ""
                  },
                  new Product
                  {
                      ProductID = 4,
                      ProductName = "Áo phông oversize",
                      Description = "Áo thun nam xanh",
                      ListPrice = 20,
                      Price = 20,
                      Price50 = 15,
                      Price100 = 10,
                      CategoryID = 1,
                      ImageUrl = ""
                  },
                  new Product
                  {
                      ProductID = 5,
                      ProductName = "Áo phông in hình sao biển",
                      Description = "Áo thun nam hồng",
                      ListPrice = 100,
                      Price = 100,
                      Price50 = 95,
                      Price100 = 90,
                      CategoryID = 1,
                      ImageUrl = ""
                  }

  );
        }
    }
}
