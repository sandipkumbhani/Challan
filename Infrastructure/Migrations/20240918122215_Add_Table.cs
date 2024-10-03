using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "document2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taluka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_mobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pro_Refe_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pro_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    MeasurementNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measur_Refe_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measur_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    MeasurOrNot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircleOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mamlatdar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Con_letter_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Con_Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Con_Refe_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Con_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Con_Amount_Dtl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount_Dtl_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    layout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uncultivat_appli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Measurment_appli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversionTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lay_out = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document2", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "document2");
        }
    }
}
