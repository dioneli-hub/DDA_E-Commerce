﻿// <auto-generated />
using DDA.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDA.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DDA.Domain.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DDA.Domain.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("DDA.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Striped cats"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Colored cats"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cool cats"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Similar cats"
                        });
                });

            modelBuilder.Entity("DDA.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "A gooood old cat.",
                            Image = "/images/cat.jpg",
                            Name = "Cat",
                            Price = 100m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "Cool cat",
                            Price = 10000m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "Another cool cat",
                            Price = 100000m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "Another one",
                            Price = 50m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "One more",
                            Price = 50000m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "The last one",
                            Price = 50000m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "COOOL CAT",
                            Image = "/images/cool.jpg",
                            Name = "Nope, this one is last",
                            Price = 50000m,
                            Quantity = 45
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "A simple grey cat.",
                            Image = "/images/grey.jpg",
                            Name = "Grey cat",
                            Price = 20m,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            Description = "Description4",
                            Image = "/images/striped.jpg",
                            Name = "Striped Cat XL",
                            Price = 50m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "Description5",
                            Image = "/images/striped2.jpg",
                            Name = "Striped Cat",
                            Price = 30m,
                            Quantity = 85
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Description6",
                            Image = "/images/striped_angry.webp",
                            Name = "Angry Strippey",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Description6",
                            Image = "/images/striped4.webp",
                            Name = "Striped cat",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            Description = "Description6",
                            Image = "/images/white.webp",
                            Name = "Another white",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Description = "Description6",
                            Image = "/images/white2.webp",
                            Name = "White cat",
                            Price = 100m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 1,
                            Description = "Description7",
                            Image = "/images/striped4.jpg",
                            Name = "Striped brother",
                            Price = 40m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            Description = "The Cat With The Boots. Don't forget to buy",
                            Image = "/images/red.jpg",
                            Name = "Red Cat",
                            Price = 40m,
                            Quantity = 300
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            Description = "Description9",
                            Image = "/images/not_cat.webp",
                            Name = "Usual cat",
                            Price = 600m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 2,
                            Description = "Thinks he's better than YOU.",
                            Image = "/images/siam.jpg",
                            Name = "Good-looking cat",
                            Price = 500m,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 3,
                            Description = "Pretends to be a cat",
                            Image = "/images/not_cat.webp",
                            Name = "Cat The Imposter",
                            Price = 100m,
                            Quantity = 60
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Description20",
                            Image = "/images/cat.jpg",
                            Name = "Cat20",
                            Price = 200m,
                            Quantity = 70
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            Description = "Description21",
                            Image = "/images/cat.jpg",
                            Name = "Cat21",
                            Price = 120m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            Description = "Description22",
                            Image = "/images/cat.jpg",
                            Name = "Cat22",
                            Price = 200m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 4,
                            Description = "Description23",
                            Image = "/images/cat.jpg",
                            Name = "Cat23",
                            Price = 50m,
                            Quantity = 150
                        });
                });

            modelBuilder.Entity("DDA.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SaltHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DDA.Domain.Item", b =>
                {
                    b.HasOne("DDA.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}