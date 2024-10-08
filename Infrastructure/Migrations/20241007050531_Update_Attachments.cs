using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Attachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceType",
                table: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentsId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_DocumentsId",
                table: "Attachments",
                column: "DocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_QuotationId",
                table: "Attachments",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Follow_DocumentsId",
                table: "Attachments",
                column: "DocumentsId",
                principalTable: "Follow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Quotation_QuotationId",
                table: "Attachments",
                column: "QuotationId",
                principalTable: "Quotation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Follow_DocumentsId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Quotation_QuotationId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_DocumentsId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_QuotationId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "DocumentsId",
                table: "Attachments");

            migrationBuilder.AddColumn<string>(
                name: "SourceType",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
