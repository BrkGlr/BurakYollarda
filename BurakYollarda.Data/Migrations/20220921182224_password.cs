using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurakYollarda.Data.Migrations
{
    public partial class password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 21, 21, 22, 24, 243, DateTimeKind.Local).AddTicks(4416));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 9, 15, 16, 27, 59, 819, DateTimeKind.Local).AddTicks(8689));
        }
    }
}
