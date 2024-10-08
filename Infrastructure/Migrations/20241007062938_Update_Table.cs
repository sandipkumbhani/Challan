using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FollowId",
                table: "Attachments",
                column: "FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Follow_FollowId",
                table: "Attachments",
                column: "FollowId",
                principalTable: "Follow",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Follow_FollowId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_FollowId",
                table: "Attachments");

            

          
        }
    }
}
