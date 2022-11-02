using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurakYollarda.Data.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 5, 18, 7, 6, 647, DateTimeKind.Local).AddTicks(2582));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 5, 16, 6, 37, 686, DateTimeKind.Local).AddTicks(1363));
        }
    }
}
