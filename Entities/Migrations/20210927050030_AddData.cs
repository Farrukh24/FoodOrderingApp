using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FoodNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodPictureUrlPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandPictureUrlPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPlaces_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_FoodPlaces_FoodPlaceId",
                        column: x => x.FoodPlaceId,
                        principalTable: "FoodPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Fast Foods" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Restaurants" });

            migrationBuilder.InsertData(
                table: "FoodPlaces",
                columns: new[] { "Id", "BrandPictureUrlPath", "CategoryId", "FoodNationality", "FoodPictureUrlPath", "Name", "SmallDescription" },
                values: new object[,]
                {
                    { 1, "https://i.pinimg.com/564x/08/49/bc/0849bc1b9e2ac21acb66ceb9fff27bcd.jpg", 1, "American", "https://i.pinimg.com/564x/84/9a/2d/849a2d6561194b8c9675371cac8bac4e.jpg", "KFC", "Fast Food" },
                    { 2, "https://media-cdn.tripadvisor.com/media/photo-p/1c/bf/3b/28/caption.jpg", 1, "American", "https://www.afisha.uz/ui/materials/2020/04/0577662_b.jpeg", "Max Way", "Fast Food" },
                    { 3, "https://www.afisha.uz/ui/catalog/2018/01/0375347.jpeg", 2, "Italian", "https://media-cdn.tripadvisor.com/media/photo-s/1c/ec/43/86/caption.jpg", "Pasternak", "Restaurant" },
                    { 4, "https://resto.uz/data/resto/43/4280/yapona-mama-2922.jpg", 2, "Japanese", "https://fastly.4sqi.net/img/general/200x200/18754087_77qAsyd3iMp8lH2W_Plb4gBwnNCIeslk9k3dmvM93co.jpg", "Yapona Mama", "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "FoodPlaceId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Chiken, tomato, salads, souse", 1, "ChiefBurger", 7.99m },
                    { 2, "bitter chiken, cheese, souse, salad", 1, "Twister", 8.99m },
                    { 3, "CheeseBurgur, Frees, Coca Cola, souse, stripes", 1, "LunchBox", 10.99m },
                    { 4, "5 stripes, feet of chiken, 10 rings, frees and more", 1, "FriendsBox", 17.99m },
                    { 5, "club sandvich chiken, frees, coca cola", 2, "FirstCombo", 5.99m },
                    { 6, "Lavash, frees, Coca cola", 2, "SecondCombo", 6.19m },
                    { 7, "Shaurma, frees, coca cola", 2, "ThirdCombo", 6.09m },
                    { 8, "burger, frees, coca cola", 2, "FourthCombo", 6.09m },
                    { 12, "Just Eat..  Fish", 3, "Farel", 60.99m },
                    { 13, "meat, salads, decoration", 3, "Welington", 57.99m },
                    { 14, "Pizza special one", 3, "GoodMan", 15.99m },
                    { 9, "Unagi light, fujiyama, akibuto, malibu, americano, losos", 4, "Seytan Set", 35.99m },
                    { 10, "chiken, soup, salad, rice", 4, "Asian Chiken", 7.99m },
                    { 11, "potato, souse, fish", 4, "Fish and Chips", 7.29m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ProductId",
                table: "Feedbacks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPlaces_CategoryId",
                table: "FoodPlaces",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FoodPlaceId",
                table: "Products",
                column: "FoodPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FoodPlaces");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
