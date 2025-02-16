using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class EditPharmacyOrderTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                schema: "Pharmacy",
                table: "PharmacyOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
