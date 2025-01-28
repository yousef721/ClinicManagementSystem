using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class EditTablePharmacCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers");

            migrationBuilder.RenameColumn(
                name: "DateOfbirth",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNationalIDCard",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNationalIDNumber",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "Pharmacy",
                table: "PharmacyCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNationalIDNumber",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNationalIDCard",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "PersonalNationalIDCard",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "PersonalNationalIDNumber",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Pharmacy",
                table: "PharmacyCustomers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                newName: "DateOfbirth");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNationalIDNumber",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalNationalIDCard",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
