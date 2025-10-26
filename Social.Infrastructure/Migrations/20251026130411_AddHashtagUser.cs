using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHashtagUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_UserId",
                table: "Hashtags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashtags_Users_UserId",
                table: "Hashtags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashtags_Users_UserId",
                table: "Hashtags");

            migrationBuilder.DropIndex(
                name: "IX_Hashtags_UserId",
                table: "Hashtags");
        }
    }
}
