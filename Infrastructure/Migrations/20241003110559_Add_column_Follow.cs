using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_column_Follow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Follow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_FollowId",
                table: "Attachment",
                column: "FollowId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_QuotationId",
                table: "Attachment",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Follow_FollowId",
                table: "Attachment",
                column: "FollowId",
                principalTable: "Follow",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Quotation_QuotationId",
                table: "Attachment",
                column: "QuotationId",
                principalTable: "Quotation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Follow_FollowId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Quotation_QuotationId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_FollowId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_QuotationId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Follow");
        }
    }
}
