using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fffffygygygf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaltHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category1" },
                    { 2, "Category2" },
                    { 3, "Category3" },
                    { 4, "Category4" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Description1", "/images/cat.jpg", "Cat1", 100m, 100 },
                    { 2, 1, "Description2", "/images/cat.jpg", "Cat2", 50m, 45 },
                    { 3, 1, "Description3", "/images/cat.jpg", "Cat3", 20m, 30 },
                    { 4, 1, "Description4", "/images/cat.jpg", "Cat4", 50m, 60 },
                    { 5, 1, "Description5", "/images/cat.jpg", "Cat5", 30m, 85 },
                    { 6, 3, "Description6", "/images/cat.jpg", "Cat6", 100m, 120 },
                    { 7, 3, "Description7", "/images/cat.jpg", "Cat7", 40m, 200 },
                    { 8, 3, "Description8", "/images/cat.jpg", "Cat8", 40m, 300 },
                    { 9, 3, "Description9", "/images/cat.jpg", "Cat9", 600m, 20 },
                    { 10, 3, "Description10", "/images/cat.jpg", "Cat10", 500m, 15 },
                    { 11, 3, "Description11", "/images/cat.jpg", "Cat11", 100m, 60 },
                    { 12, 2, "Description12", "/images/cat.jpg", "Cat12", 50m, 212 },
                    { 13, 2, "Description13", "/images/cat.jpg", "Cat13", 50m, 112 },
                    { 14, 2, "Description14", "/images/cat.jpg", "Cat14", 70m, 90 },
                    { 15, 2, "Description15", "/images/cat.jpg", "Cat15", 120m, 95 },
                    { 16, 2, "Description16", "/images/cat.jpg", "Cat16", 15m, 100 },
                    { 17, 2, "Description17", "/images/cat.jpg", "Cat17", 20m, 73 },
                    { 18, 4, "Description18", "/images/cat.jpg", "Cat18", 100m, 50 },
                    { 19, 4, "Description19", "/images/cat.jpg", "Cat19", 150m, 60 },
                    { 20, 4, "Description20", "/images/cat.jpg", "Cat20", 200m, 70 },
                    { 21, 4, "Description21", "/images/cat.jpg", "Cat21", 120m, 120 },
                    { 22, 4, "Description22", "/images/cat.jpg", "Cat22", 200m, 100 },
                    { 23, 4, "Description23", "/images/cat.jpg", "Cat23", 50m, 150 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "SaltHash" },
                values: new object[,]
                {
                    { 1, "string", "Dastan", "vtqMBmkyjYWTiUQgoQA/f1f4dKQ/tEOsfRYVp8bhXOI=", "osWQVLjdW582FSVB6aMwDg==" },
                    { 2, "string1", "Diana", "Iq+pXfcm8IoCLOFsDBW1NsTo63R86piURQ/yJrWPXzU=", "/ZcP5+73VeaG0k1WH6eddw==" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
