using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMember_Group_GroupId",
                table: "GroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMember_Users_UserId",
                table: "GroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_Group_GroupId",
                table: "GroupPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PageMember_Page_PageId",
                table: "PageMember");

            migrationBuilder.DropForeignKey(
                name: "FK_PageMember_Users_UserId",
                table: "PageMember");

            migrationBuilder.DropForeignKey(
                name: "FK_PagePosts_Page_PageId",
                table: "PagePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageMember",
                table: "PageMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                table: "Page");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMember",
                table: "GroupMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "PageMember",
                newName: "PageMembers");

            migrationBuilder.RenameTable(
                name: "Page",
                newName: "Pages");

            migrationBuilder.RenameTable(
                name: "GroupMember",
                newName: "GroupMembers");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_PageMember_UserId",
                table: "PageMembers",
                newName: "IX_PageMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMember_UserId",
                table: "GroupMembers",
                newName: "IX_GroupMembers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageMembers",
                table: "PageMembers",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMembers",
                table: "GroupMembers",
                columns: new[] { "GroupId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Groups_GroupId",
                table: "GroupMembers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Users_UserId",
                table: "GroupMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Groups_GroupId",
                table: "GroupPosts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageMembers_Pages_PageId",
                table: "PageMembers",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageMembers_Users_UserId",
                table: "PageMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PagePosts_Pages_PageId",
                table: "PagePosts",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Groups_GroupId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Users_UserId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_Groups_GroupId",
                table: "GroupPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_PageMembers_Pages_PageId",
                table: "PageMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_PageMembers_Users_UserId",
                table: "PageMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_PagePosts_Pages_PageId",
                table: "PagePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageMembers",
                table: "PageMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMembers",
                table: "GroupMembers");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page");

            migrationBuilder.RenameTable(
                name: "PageMembers",
                newName: "PageMember");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "GroupMembers",
                newName: "GroupMember");

            migrationBuilder.RenameIndex(
                name: "IX_PageMembers_UserId",
                table: "PageMember",
                newName: "IX_PageMember_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMember",
                newName: "IX_GroupMember_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                table: "Page",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageMember",
                table: "PageMember",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMember",
                table: "GroupMember",
                columns: new[] { "GroupId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMember_Group_GroupId",
                table: "GroupMember",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMember_Users_UserId",
                table: "GroupMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_Group_GroupId",
                table: "GroupPosts",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageMember_Page_PageId",
                table: "PageMember",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageMember_Users_UserId",
                table: "PageMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PagePosts_Page_PageId",
                table: "PagePosts",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
