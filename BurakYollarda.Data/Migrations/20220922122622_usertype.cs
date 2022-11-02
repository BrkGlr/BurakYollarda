using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurakYollarda.Data.Migrations
{
    public partial class usertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntity_Posts_PostsId",
                table: "CommentEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity");

            migrationBuilder.RenameTable(
                name: "CommentEntity",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntity_PostsId",
                table: "Comments",
                newName: "IX_Comments_PostsId");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UserType" },
                values: new object[] { new DateTime(2022, 9, 22, 15, 26, 22, 630, DateTimeKind.Local).AddTicks(3133), "12345", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostsId",
                table: "Comments",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostsId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostsId",
                table: "CommentEntity",
                newName: "IX_CommentEntity_PostsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2022, 9, 21, 21, 22, 24, 243, DateTimeKind.Local).AddTicks(4416), "123456" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntity_Posts_PostsId",
                table: "CommentEntity",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
