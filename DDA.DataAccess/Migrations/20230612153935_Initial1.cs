using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDA.DataAccess.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    SaltHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Striped cats" },
                    { 2, "Colored cats" },
                    { 3, "Cool cats" },
                    { 4, "Similar cats" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, "A gooood old cat.", "/images/cat.jpg", "Cat", 100m, 100 },
                    { 2, 3, "COOOL CAT", "/images/cool.jpg", "Cool cat", 10000m, 45 },
                    { 3, 3, "COOOL CAT", "/images/cool.jpg", "Another cool cat", 100000m, 45 },
                    { 4, 3, "COOOL CAT", "/images/cool.jpg", "Another one", 50m, 45 },
                    { 5, 3, "COOOL CAT", "/images/cool.jpg", "One more", 50000m, 45 },
                    { 6, 3, "COOOL CAT", "/images/cool.jpg", "The last one", 50000m, 45 },
                    { 7, 3, "COOOL CAT", "/images/cool.jpg", "Nope, this one is last", 50000m, 45 },
                    { 8, 2, "A simple grey cat.", "/images/grey.jpg", "Grey cat", 20m, 30 },
                    { 9, 1, "Description4", "/images/striped.jpg", "Striped Cat XL", 50m, 60 },
                    { 10, 1, "Description5", "/images/striped2.jpg", "Striped Cat", 30m, 85 },
                    { 11, 3, "Description6", "/images/striped_angry.webp", "Angry Strippey", 100m, 120 },
                    { 12, 3, "Description6", "/images/striped4.webp", "Striped cat", 100m, 120 },
                    { 13, 2, "Description6", "/images/white.webp", "Another white", 100m, 120 },
                    { 14, 2, "Description6", "/images/white2.webp", "White cat", 100m, 120 },
                    { 15, 1, "Description7", "/images/striped4.jpg", "Striped brother", 40m, 200 },
                    { 16, 2, "The Cat With The Boots. Don't forget to buy", "/images/red.jpg", "Red Cat", 40m, 300 },
                    { 17, 3, "Description9", "/images/not_cat.webp", "Usual cat", 600m, 20 },
                    { 18, 2, "Thinks he's better than YOU.", "/images/siam.jpg", "Good-looking cat", 500m, 15 },
                    { 19, 3, "Pretends to be a cat", "/images/not_cat.webp", "Cat The Imposter", 100m, 60 },
                    { 20, 4, "Description20", "/images/cat.jpg", "Cat20", 200m, 70 },
                    { 21, 4, "Description21", "/images/cat.jpg", "Cat21", 120m, 120 },
                    { 22, 4, "Description22", "/images/cat.jpg", "Cat22", 200m, 100 },
                    { 23, 4, "Description23", "/images/cat.jpg", "Cat23", 50m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
