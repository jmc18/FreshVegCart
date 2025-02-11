using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreshVegCart.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Placed")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "UserAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/avocado.png", "Avocado", 1.99m, "each" },
                    { 2L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/beet.png", "Beet", 0.99m, "each" },
                    { 3L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/bell_pepper.png", "Bell Pepper", 1.50m, "each" },
                    { 4L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/broccoli.png", "Broccoli", 2.00m, "each" },
                    { 5L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cabbage.png", "Cabbage", 1.20m, "each" },
                    { 6L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/capsicum.png", "Capsicum", 1.80m, "each" },
                    { 7L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/carrot.png", "Carrot", 0.80m, "kg" },
                    { 8L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cauliflower.png", "Cauliflower", 2.50m, "each" },
                    { 9L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/coriander.png", "Coriander", 0.70m, "bunch" },
                    { 10L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/corn.png", "Corn", 1.00m, "each" },
                    { 11L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cucumber.png", "Cucumber", 0.90m, "each" },
                    { 12L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/eggplant.png", "Eggplant", 1.75m, "each" },
                    { 13L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/farmer.png", "Farmer", 5.00m, "each" },
                    { 14L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ginger.png", "Ginger", 2.20m, "kg" },
                    { 15L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/green_beans.png", "Green Beans", 1.60m, "kg" },
                    { 16L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ladyfinger.png", "Ladyfinger", 1.10m, "kg" },
                    { 17L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/lettuce.png", "Lettuce", 1.30m, "each" },
                    { 18L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/mushroom.png", "Mushroom", 2.80m, "kg" },
                    { 19L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/onion.png", "Onion", 0.60m, "kg" },
                    { 20L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pea.png", "Pea", 1.40m, "kg" },
                    { 21L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/potato.png", "Potato", 0.50m, "kg" },
                    { 22L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pumpkin.png", "Pumpkin", 3.00m, "each" },
                    { 23L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/radish.png", "Radish", 0.85m, "bunch" },
                    { 24L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/red_chili.png", "Red Chili", 1.50m, "kg" },
                    { 25L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/spinach.png", "Spinach", 1.20m, "bunch" },
                    { 26L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/tomato.png", "Tomato", 0.95m, "kg" },
                    { 27L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/turnip.png", "Turnip", 0.75m, "each" },
                    { 28L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/vegetables.png", "Vegetables", 4.00m, "each" },
                    { 29L, "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/yellow_capsicum.png", "Yellow Capsicum", 1.80m, "each" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
