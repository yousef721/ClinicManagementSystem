using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class updatePharmacysetion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicineCount",
                schema: "Pharmacy",
                table: "MedicineOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                schema: "Pharmacy",
                table: "PharmacyOrders");

            migrationBuilder.DropColumn(
                name: "OrderCount",
                schema: "Pharmacy",
                table: "PharmacyOrders");

            migrationBuilder.DropColumn(
                name: "MedicineCount",
                schema: "Pharmacy",
                table: "MedicineOrders");
        }
    }
}
