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

            //Items
            //Electronics Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "test1",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 120,
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "test2",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 120,
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Name = "test6",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 500,
                Quantity = 120,
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Name = "test5",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 900,
                Quantity = 120,
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 5,
                Name = "test7",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 900,
                Quantity = 120,
                CategoryId = 1
            });


            //Shoes Category
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 6,
                Name = "test3",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 120,
                CategoryId = 2
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 7,
                Name = "test4",
                Description = "Air Pods - in-ear wireless headphones",
                Image = "/images/cat.jpg",
                Price = 100,
                Quantity = 120,
                CategoryId = 2
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

            //Shopping Cart
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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }

    
}