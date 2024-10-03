using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_column_Follow_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentDetails",
                table: "DocumentDetails");

            migrationBuilder.RenameTable(
                name: "DocumentDetails",
                newName: "Follow");

            migrationBuilder.AddColumn<string>(
                name: "BorrowerEmail",
                table: "Follow",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow",
                table: "Follow",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "BorrowerEmail",
                table: "Follow");

            migrationBuilder.RenameTable(
                name: "Follow",
                newName: "DocumentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentDetails",
                table: "DocumentDetails",
                column: "Id");
        }
    }
}
