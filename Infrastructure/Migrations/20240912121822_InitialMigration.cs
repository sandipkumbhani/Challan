using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    BorrowersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDharaCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DharaCenterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DharaCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitySurveyNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitySurvey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityTalati = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GramPanchayat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPayment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDetails");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
