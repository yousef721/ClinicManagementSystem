using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusMedicines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Pharmacy",
                table: "Medicines");
        }
    }
}
