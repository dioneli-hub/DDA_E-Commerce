using DDA.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDA.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "Cat",
                Description = "A gooood old cat.",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 100,
                CategoryId = 2

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "Cool cat",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 10000,
                Quantity = 45,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Name = "Another cool cat",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 100000,
                Quantity = 45,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Name = "Another one",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 50,
                Quantity = 45,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 5,
                Name = "One more",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 50000,
                Quantity = 45,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 6,
                Name = "The last one",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 50000,
                Quantity = 45,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 7,
                Name = "Nope, this one is last",
                Description = "COOOL CAT",
                Image = "/images/cool.jpg",
                Price = 50000,
                Quantity = 45,
                CategoryId = 3

            });


            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 8,
                Name = "Grey cat",
                Description = "A simple grey cat.",
                Image = "/images/grey.jpg",
                Price = 20,
                Quantity = 30,
                CategoryId = 2

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 9,
                Name = "Striped Cat XL",
                Description = "Description4",
                Image = "/images/striped.jpg",
                Price = 50,
                Quantity = 60,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 10,
                Name = "Striped Cat",
                Description = "Description5",
                Image = "/images/striped2.jpg",
                Price = 30,
                Quantity = 85,
                CategoryId = 1

            });
            //Electronics Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 11,
                Name = "Angry Strippey",
                Description = "Description6",
                Image = "/images/striped_angry.webp",
                Price = 100,
                Quantity = 120,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 12,
                Name = "Striped cat",
                Description = "Description6",
                Image = "/images/striped4.webp",
                Price = 100,
                Quantity = 120,
                CategoryId = 3

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 13,
                Name = "Another white",
                Description = "Description6",
                Image = "/images/white.webp",
                Price = 100,
                Quantity = 120,
                CategoryId = 2

            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 14,
                Name = "White cat",
                Description = "Description6",
                Image = "/images/white2.webp",
                Price = 100,
                Quantity = 120,
                CategoryId = 2

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 15,
                Name = "Striped brother",
                Description = "Description7",
                Image = "/images/striped4.jpg",
                Price = 40,
                Quantity = 200,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 16,
                Name = "Red Cat",
                Description = "The Cat With The Boots. Don't forget to buy",
                Image = "/images/red.jpg",
                Price = 40,
                Quantity = 300,
                CategoryId = 2

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 17,
                Name = "Usual cat",
                Description = "Description9",
                Image = "/images/not_cat.webp",
                Price = 600,
                Quantity = 20,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 18,
                Name = "Good-looking cat",
                Description = "Thinks he's better than YOU.",
                Image = "/images/siam.jpg",
                Price = 500,
                Quantity = 15,
                CategoryId = 2

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 19,
                Name = "Cat The Imposter",
                Description = "Pretends to be a cat",
                Image = "/images/not_cat.webp",
                Price = 100,
                Quantity = 60,
                CategoryId = 3
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 20,
                Name = "Cat20",
                Description = "Description20",
                Image = "/images/cat.jpg",
                Price = 200,
                Quantity = 70,
                CategoryId = 4
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 21,
                Name = "Cat21",
                Description = "Description21",
                Image = "/images/cat.jpg",
                Price = 120,
                Quantity = 120,
                CategoryId = 4
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 22,
                Name = "Cat22",
                Description = "Description22",
                Image = "/images/cat.jpg",
                Price = 200,
                Quantity = 100,
                CategoryId = 4
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 23,
                Name = "Cat23",
                Description = "Description23",
                Image = "/images/cat.jpg",
                Price = 50,
                Quantity = 150,
                CategoryId = 4
            });


            //Categories
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Striped cats"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Colored cats"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Cool cats"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "Similar cats"
            });

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }

    
}