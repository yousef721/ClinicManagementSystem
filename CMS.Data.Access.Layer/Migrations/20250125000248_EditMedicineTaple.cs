using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class EditMedicineTaple : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Pharmacy",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Pharmacy",
                table: "Medicines");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000,
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PurchasePrice",
                schema: "Pharmacy",
                table: "Medicines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "Pharmacy",
                table: "Medicines",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
