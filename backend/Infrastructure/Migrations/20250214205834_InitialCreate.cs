using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    model = table.Column<string>(type: "TEXT", nullable: true),
                    brand = table.Column<string>(type: "TEXT", nullable: true),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    rented = table.Column<int>(type: "INTEGER", nullable: false),
                    id_price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    document = table.Column<string>(type: "TEXT", nullable: true),
                    document_type = table.Column<int>(type: "INTEGER", nullable: false),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PayType",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    value = table.Column<decimal>(type: "TEXT", nullable: false),
                    discount = table.Column<decimal>(type: "TEXT", nullable: false),
                    acceptDiscount = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_customer = table.Column<int>(type: "INTEGER", nullable: false),
                    id_car = table.Column<int>(type: "INTEGER", nullable: false),
                    day = table.Column<DateTime>(type: "TEXT", nullable: false),
                    day_remaining = table.Column<DateTime>(type: "TEXT", nullable: false),
                    pay_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    price_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rent_Car_id_car",
                        column: x => x.id_car,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_Customer_id_customer",
                        column: x => x.id_customer,
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_id_car",
                table: "Rent",
                column: "id_car");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_id_customer",
                table: "Rent",
                column: "id_customer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "PayType");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
