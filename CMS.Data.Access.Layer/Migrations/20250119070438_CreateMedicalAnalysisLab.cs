using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class CreateMedicalAnalysisLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MedicalAnalysisLab");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Clinic",
                table: "RequestDoctors",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Clinic",
                table: "RequestDoctors",
                newName: "PersonalNationalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Clinic",
                table: "RequestClinicReceptionists",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Clinic",
                table: "RequestClinicReceptionists",
                newName: "PersonalNationalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Pharmacy",
                table: "PharmacyDeliveryRepresentatives",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Pharmacy",
                table: "PharmacyDeliveryRepresentatives",
                newName: "PersonalNationalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Pharmacy",
                table: "Pharmacists",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Pharmacy",
                table: "Pharmacists",
                newName: "PersonalNationalIDCard");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Clinic",
                table: "Patient",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Clinic",
                table: "Doctors",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Clinic",
                table: "Doctors",
                newName: "PersonalNationalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalIDCard",
                schema: "Clinic",
                table: " ClinicReceptionists",
                newName: "PersonalNationalIDNumber");

            migrationBuilder.RenameColumn(
                name: "NationalID",
                schema: "Clinic",
                table: " ClinicReceptionists",
                newName: "PersonalNationalIDCard");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Appointment",
                schema: "Clinic",
                table: "Schedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "Patient",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisLabCustomers",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfbirth = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisLabCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisLabs",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisLabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisLabBranches",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    AnalysisDuration = table.Column<TimeOnly>(type: "time", nullable: false),
                    MedicalAnalysisLabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisLabBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisLabBranches_MedicalAnalysisLabs_MedicalAnalysisLabId",
                        column: x => x.MedicalAnalysisLabId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisTests",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<TimeOnly>(type: "time", nullable: false),
                    MedicalAnalysisLabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisTests_MedicalAnalysisLabs_MedicalAnalysisLabId",
                        column: x => x.MedicalAnalysisLabId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisLabAppointments",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Appointment = table.Column<TimeOnly>(type: "time", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAnalysisLabBranchId = table.Column<int>(type: "int", nullable: false),
                    MedicalAnalysisLabCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisLabAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisLabAppointments_MedicalAnalysisLabBranches_MedicalAnalysisLabBranchId",
                        column: x => x.MedicalAnalysisLabBranchId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisLabAppointments_MedicalAnalysisLabCustomers_MedicalAnalysisLabCustomerId",
                        column: x => x.MedicalAnalysisLabCustomerId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisLabReceptionists",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalAnalysisLabBranchId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisLabReceptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisLabReceptionists_MedicalAnalysisLabBranches_MedicalAnalysisLabBranchId",
                        column: x => x.MedicalAnalysisLabBranchId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisSpecialists",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    MedicalAnalysisLabBranchId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    MedicalDegree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisSpecialists_MedicalAnalysisLabBranches_MedicalAnalysisLabBranchId",
                        column: x => x.MedicalAnalysisLabBranchId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestMedicalAnalysisLabReceptionists",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalAnalysisLabBranchId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedSalary = table.Column<double>(type: "float", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMedicalAnalysisLabReceptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestMedicalAnalysisLabReceptionists_MedicalAnalysisLabBranches_MedicalAnalysisLabBranchId",
                        column: x => x.MedicalAnalysisLabBranchId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestMedicalAnalysisSpecialists",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpectedSalary = table.Column<double>(type: "float", nullable: false),
                    MedicalAnalysisLabBranchId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalNationalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    MedicalDegree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMedicalAnalysisSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestMedicalAnalysisSpecialists_MedicalAnalysisLabBranches_MedicalAnalysisLabBranchId",
                        column: x => x.MedicalAnalysisLabBranchId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisTestCustomers",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    MedicalAnalysisTestId = table.Column<int>(type: "int", nullable: false),
                    MedicalAnalysisLabCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisTestCustomers", x => new { x.MedicalAnalysisLabCustomerId, x.MedicalAnalysisTestId });
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisTestCustomers_MedicalAnalysisLabCustomers_MedicalAnalysisLabCustomerId",
                        column: x => x.MedicalAnalysisLabCustomerId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisTestCustomers_MedicalAnalysisTests_MedicalAnalysisTestId",
                        column: x => x.MedicalAnalysisTestId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAnalysisTestResults",
                schema: "MedicalAnalysisLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Report = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MediacalAnalysisTestId = table.Column<int>(type: "int", nullable: false),
                    MedicalAnalysisLabCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAnalysisTestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisTestResults_MedicalAnalysisLabCustomers_MedicalAnalysisLabCustomerId",
                        column: x => x.MedicalAnalysisLabCustomerId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisLabCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAnalysisTestResults_MedicalAnalysisTests_MediacalAnalysisTestId",
                        column: x => x.MediacalAnalysisTestId,
                        principalSchema: "MedicalAnalysisLab",
                        principalTable: "MedicalAnalysisTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisLabAppointments_MedicalAnalysisLabBranchId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabAppointments",
                column: "MedicalAnalysisLabBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisLabAppointments_MedicalAnalysisLabCustomerId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabAppointments",
                column: "MedicalAnalysisLabCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisLabBranches_MedicalAnalysisLabId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabBranches",
                column: "MedicalAnalysisLabId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisLabReceptionists_MedicalAnalysisLabBranchId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisLabReceptionists",
                column: "MedicalAnalysisLabBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisSpecialists_MedicalAnalysisLabBranchId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisSpecialists",
                column: "MedicalAnalysisLabBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisTestCustomers_MedicalAnalysisTestId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisTestCustomers",
                column: "MedicalAnalysisTestId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisTestResults_MediacalAnalysisTestId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisTestResults",
                column: "MediacalAnalysisTestId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisTestResults_MedicalAnalysisLabCustomerId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisTestResults",
                column: "MedicalAnalysisLabCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAnalysisTests_MedicalAnalysisLabId",
                schema: "MedicalAnalysisLab",
                table: "MedicalAnalysisTests",
                column: "MedicalAnalysisLabId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMedicalAnalysisLabReceptionists_MedicalAnalysisLabBranchId",
                schema: "MedicalAnalysisLab",
                table: "RequestMedicalAnalysisLabReceptionists",
                column: "MedicalAnalysisLabBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMedicalAnalysisSpecialists_MedicalAnalysisLabBranchId",
                schema: "MedicalAnalysisLab",
                table: "RequestMedicalAnalysisSpecialists",
                column: "MedicalAnalysisLabBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAnalysisLabAppointments",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisLabReceptionists",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisSpecialists",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisTestCustomers",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisTestResults",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "RequestMedicalAnalysisLabReceptionists",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "RequestMedicalAnalysisSpecialists",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisLabCustomers",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisTests",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisLabBranches",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropTable(
                name: "MedicalAnalysisLabs",
                schema: "MedicalAnalysisLab");

            migrationBuilder.DropColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "RequestDoctors",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "RequestDoctors",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "RequestClinicReceptionists",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "RequestClinicReceptionists",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Pharmacy",
                table: "PharmacyDeliveryRepresentatives",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Pharmacy",
                table: "PharmacyDeliveryRepresentatives",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Pharmacy",
                table: "Pharmacists",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Pharmacy",
                table: "Pharmacists",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "Patient",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: "Doctors",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: "Doctors",
                newName: "NationalID");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDNumber",
                schema: "Clinic",
                table: " ClinicReceptionists",
                newName: "PersonalIDCard");

            migrationBuilder.RenameColumn(
                name: "PersonalNationalIDCard",
                schema: "Clinic",
                table: " ClinicReceptionists",
                newName: "NationalID");

            migrationBuilder.AlterColumn<string>(
                name: "Appointment",
                schema: "Clinic",
                table: "Schedules",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }
    }
}
