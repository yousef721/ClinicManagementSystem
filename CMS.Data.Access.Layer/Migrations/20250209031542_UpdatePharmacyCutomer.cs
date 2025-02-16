using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePharmacyCutomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyOrders_PharmacyDeliveryRepresentatives_PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyCustomerId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyCustomers_ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyCustomers_AspNetUsers_ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyOrders_PharmacyDeliveryRepresentatives_PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                column: "PharmacyDeliveryRepresentativeId",
                principalSchema: "Pharmacy",
                principalTable: "PharmacyDeliveryRepresentatives",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyCustomers_AspNetUsers_ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyOrders_PharmacyDeliveryRepresentatives_PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyCustomers_ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PharmacyCustomerId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyOrders_PharmacyDeliveryRepresentatives_PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                column: "PharmacyDeliveryRepresentativeId",
                principalSchema: "Pharmacy",
                principalTable: "PharmacyDeliveryRepresentatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
