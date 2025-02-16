using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePharmacyOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                schema: "Pharmacy",
                table: "PharmacyOrders");
        }
    }
}
