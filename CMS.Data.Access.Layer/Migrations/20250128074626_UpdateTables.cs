using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAppointments_Patient_PatientId",
                schema: "Clinic",
                table: "PatientAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Patient_PatientId",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientId",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "Clinic",
                table: "Patients",
                newName: "LastVisitDate");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                schema: "Clinic",
                table: "Patients",
                type: "varchar(4)",
                unicode: false,
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                schema: "Clinic",
                table: "Patients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Clinic",
                table: "Patients",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalAnalysis",
                schema: "Clinic",
                table: "Patients",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PatientHistories",
                schema: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Clinic",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistories_PatientId",
                schema: "Clinic",
                table: "PatientHistories",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAppointments_Patients_PatientId",
                schema: "Clinic",
                table: "PatientAppointments",
                column: "PatientId",
                principalSchema: "Clinic",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAppointments_Patients_PatientId",
                schema: "Clinic",
                table: "PatientAppointments");

            migrationBuilder.DropTable(
                name: "PatientHistories",
                schema: "Clinic");

            migrationBuilder.DropColumn(
                name: "BloodType",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalAnalysis",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Occupation",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Region",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "Clinic",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastVisitDate",
                schema: "Clinic",
                table: "Patients",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Clinic",
                table: "Patients",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                schema: "Clinic",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastVisitDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MedicalAnalysis = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientId",
                schema: "Clinic",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAppointments_Patient_PatientId",
                schema: "Clinic",
                table: "PatientAppointments",
                column: "PatientId",
                principalSchema: "Clinic",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Patient_PatientId",
                schema: "Clinic",
                table: "Patients",
                column: "PatientId",
                principalSchema: "Clinic",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
