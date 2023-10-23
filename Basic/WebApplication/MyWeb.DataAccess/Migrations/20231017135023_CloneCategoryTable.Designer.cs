﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWeb.DataAcess;

#nullable disable

namespace MyWeb.DataAcess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017135023_CloneCategoryTable")]
    partial class CloneCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWeb.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CaterogyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CaterogyName = "Food and beverage",
                            DisplayOrder = 1
                        },
                        new
                        {
                            CategoryID = 2,
                            CaterogyName = "Fast food",
                            DisplayOrder = 2
                        },
                        new
                        {
                            CategoryID = 3,
                            CaterogyName = "Spicy food",
                            DisplayOrder = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
