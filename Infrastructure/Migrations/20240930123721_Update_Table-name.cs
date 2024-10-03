using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_document2",
                table: "document2");

            migrationBuilder.RenameTable(
                name: "document2",
                newName: "Quotation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotation",
                table: "Quotation",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotation",
                table: "Quotation");

            migrationBuilder.RenameTable(
                name: "Quotation",
                newName: "document2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document2",
                table: "document2",
                column: "Id");
        }
    }
}
