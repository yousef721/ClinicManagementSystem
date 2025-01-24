using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Access.Layer.Migrations
{
    /// <inheritdoc />
    public partial class CreatepharmacyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pharmacy");

            migrationBuilder.CreateTable(
                name: "MedicineManufactories",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineManufactories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacists",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(type: "float", nullable: false),
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
                    PersonalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    MedicalDegree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyCategories",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyCustomers",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_PharmacyCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyDeliveryRepresentatives",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    PersonalIDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndWork = table.Column<TimeOnly>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyDeliveryRepresentatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PharmacyCategoryId = table.Column<int>(type: "int", nullable: false),
                    MedicineManufactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineManufactories_MedicineManufactoryId",
                        column: x => x.MedicineManufactoryId,
                        principalSchema: "Pharmacy",
                        principalTable: "MedicineManufactories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_PharmacyCategories_PharmacyCategoryId",
                        column: x => x.PharmacyCategoryId,
                        principalSchema: "Pharmacy",
                        principalTable: "PharmacyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyOrders",
                schema: "Pharmacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ShipmentStatus = table.Column<int>(type: "int", nullable: false),
                    PharmacyCustomerId = table.Column<int>(type: "int", nullable: false),
                    PharmacyDeliveryRepresentativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyOrders_PharmacyCustomers_PharmacyCustomerId",
                        column: x => x.PharmacyCustomerId,
                        principalSchema: "Pharmacy",
                        principalTable: "PharmacyCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyOrders_PharmacyDeliveryRepresentatives_PharmacyDeliveryRepresentativeId",
                        column: x => x.PharmacyDeliveryRepresentativeId,
                        principalSchema: "Pharmacy",
                        principalTable: "PharmacyDeliveryRepresentatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineOrders",
                schema: "Pharmacy",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    PharmacyOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineOrders", x => new { x.MedicineId, x.PharmacyOrderId });
                    table.ForeignKey(
                        name: "FK_MedicineOrders_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "Pharmacy",
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineOrders_PharmacyOrders_PharmacyOrderId",
                        column: x => x.PharmacyOrderId,
                        principalSchema: "Pharmacy",
                        principalTable: "PharmacyOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineOrders_PharmacyOrderId",
                schema: "Pharmacy",
                table: "MedicineOrders",
                column: "PharmacyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineManufactoryId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "MedicineManufactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmacyCategoryId",
                schema: "Pharmacy",
                table: "Medicines",
                column: "PharmacyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyOrders_PharmacyCustomerId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                column: "PharmacyCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyOrders_PharmacyDeliveryRepresentativeId",
                schema: "Pharmacy",
                table: "PharmacyOrders",
                column: "PharmacyDeliveryRepresentativeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineOrders",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Pharmacists",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Medicines",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyOrders",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "MedicineManufactories",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyCategories",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyCustomers",
                schema: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyDeliveryRepresentatives",
                schema: "Pharmacy");
        }
    }
}
