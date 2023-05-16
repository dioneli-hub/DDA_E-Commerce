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

            //    //Items
            //    //Category1
            //    modelBuilder.Entity<Item>().HasData(new Item
            //    {
            //        Id = 1,
            //        Name = "test1",
            //        Description = "Air Pods - in-ear wireless headphones",
            //        Image = "/images/cat.jpg",
            //        Price = 100,
            //        Quantity = 120,
            //        CategoryId = 1
            //    });

            //    modelBuilder.Entity<Item>().HasData(new Item
            //    {
            //        Id = 2,
            //        Name = "test2",
            //        Description = "Air Pods - in-ear wireless headphones",
            //        Image = "/images/cat.jpg",
            //        Price = 100,
            //        Quantity = 120,
            //        CategoryId = 1
            //    });

            //    //Category2
            //    modelBuilder.Entity<Item>().HasData(new Item
            //    {
            //        Id = 3,
            //        Name = "test3",
            //        Description = "Air Pods - in-ear wireless headphones",
            //        Image = "/images/cat.jpg",
            //        Price = 100,
            //        Quantity = 120,
            //        CategoryId = 2
            //    });

            //    modelBuilder.Entity<Item>().HasData(new Item
            //    {
            //        Id = 4,
            //        Name = "test4",
            //        Description = "Air Pods - in-ear wireless headphones",
            //        Image = "/images/cat.jpg",
            //        Price = 100,
            //        Quantity = 120,
            //        CategoryId = 2
            //    });

            //    //Users
            //    modelBuilder.Entity<User>().HasData(new User
            //    {
            //        Id = 1,
            //        Name = "Dastan",
            //        PasswordHash = "vtqMBmkyjYWTiUQgoQA/f1f4dKQ/tEOsfRYVp8bhXOI=",
            //        SaltHash = "osWQVLjdW582FSVB6aMwDg==",
            //        Email = "string"


            //    });
            //    modelBuilder.Entity<User>().HasData(new User
            //    {
            //        Id = 2,
            //        Name = "Diana",
            //        PasswordHash = "Iq+pXfcm8IoCLOFsDBW1NsTo63R86piURQ/yJrWPXzU=",
            //        SaltHash = "/ZcP5+73VeaG0k1WH6eddw==",
            //        Email = "string1"
            //    });

            //    //Shopping Cart
            //    modelBuilder.Entity<Cart>().HasData(new Cart
            //    {
            //        Id = 1,
            //        UserId = 1

            //    });
            //    modelBuilder.Entity<Cart>().HasData(new Cart
            //    {
            //        Id = 2,
            //        UserId = 2

            //    });

            //    modelBuilder.Entity<CartItem>().HasData(new CartItem
            //    {
            //        Id = 1,
            //        CartId = 1,
            //        ItemId = 1,
            //        Quantity = 1
            //    });

            //    modelBuilder.Entity<CartItem>().HasData(new CartItem
            //    {
            //        Id = 2,
            //        CartId = 2,
            //        ItemId = 2,
            //        Quantity = 2
            //    });

            //    //Categories
            //    modelBuilder.Entity<Category>().HasData(new Category
            //    {
            //        Id = 1,
            //        Name = "Category1"
            //    });
            //    modelBuilder.Entity<Category>().HasData(new Category
            //    {
            //        Id = 2,
            //        Name = "Category2"
            //    });
            //}

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "Cat1",
                Description = "Description1",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 100,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "Cat2",
                Description = "Description2",
                Image = "/images/cat.jpg",
                Price = 50,
                Quantity = 45,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Name = "Cat3",
                Description = "Description3",
                Image = "/images/cat.jpg",
                Price = 20,
                Quantity = 30,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Name = "Cat4",
                Description = "Description4",
                Image = "/images/cat.jpg",
                Price = 50,
                Quantity = 60,
                CategoryId = 1

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 5,
                Name = "Cat5",
                Description = "Description5",
                Image = "/images/cat.jpg",
                Price = 30,
                Quantity = 85,
                CategoryId = 1

            });
            //Electronics Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 6,
                Name = "Cat6",
                Description = "Description6",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 120,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 7,
                Name = "Cat7",
                Description = "Description7",
                Image = "/images/cat.jpg",
                Price = 40,
                Quantity = 200,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 8,
                Name = "Cat8",
                Description = "Description8",
                Image = "/images/cat.jpg",
                Price = 40,
                Quantity = 300,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 9,
                Name = "Cat9",
                Description = "Description9",
                Image = "/images/cat.jpg",
                Price = 600,
                Quantity = 20,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 10,
                Name = "Cat10",
                Description = "Description10",
                Image = "/images/cat.jpg",
                Price = 500,
                Quantity = 15,
                CategoryId = 3

            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 11,
                Name = "Cat11",
                Description = "Description11",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 60,
                CategoryId = 3
            });
            //Furniture Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 12,
                Name = "Cat12",
                Description = "Description12",
                Image = "/images/cat.jpg",
                Price = 50,
                Quantity = 212,
                CategoryId = 2
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 13,
                Name = "Cat13",
                Description = "Description13",
                Image = "/images/cat.jpg",
                Price = 50,
                Quantity = 112,
                CategoryId = 2
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 14,
                Name = "Cat14",
                Description = "Description14",
                Image = "/images/cat.jpg",
                Price = 70,
                Quantity = 90,
                CategoryId = 2
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 15,
                Name = "Cat15",
                Description = "Description15",
                Image = "/images/cat.jpg",
                Price = 120,
                Quantity = 95,
                CategoryId = 2
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 16,
                Name = "Cat16",
                Description = "Description16",
                Image = "/images/cat.jpg",
                Price = 15,
                Quantity = 100,
                CategoryId = 2
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 17,
                Name = "Cat17",
                Description = "Description17",
                Image = "/images/cat.jpg",
                Price = 20,
                Quantity = 73,
                CategoryId = 2
            });
            //Shoes Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 18,
                Name = "Cat18",
                Description = "Description18",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 50,
                CategoryId = 4
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 19,
                Name = "Cat19",
                Description = "Description19",
                Image = "/images/cat.jpg",
                Price = 150,
                Quantity = 60,
                CategoryId = 4
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

            //Users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Dastan",
                PasswordHash = "vtqMBmkyjYWTiUQgoQA/f1f4dKQ/tEOsfRYVp8bhXOI=",
                SaltHash = "osWQVLjdW582FSVB6aMwDg==",
                Email = "string"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Diana",
                PasswordHash = "Iq+pXfcm8IoCLOFsDBW1NsTo63R86piURQ/yJrWPXzU=",
                SaltHash = "/ZcP5+73VeaG0k1WH6eddw==",
                Email = "string1"

            });

            //Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2

            });

            //Categories
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Category1"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Category2"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Category3"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "Category4"
            });
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }

    
}