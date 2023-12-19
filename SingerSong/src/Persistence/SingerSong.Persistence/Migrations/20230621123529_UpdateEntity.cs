using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingerSong.Persistence.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SingerPhoto",
                table: "Singers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverPhoto",
                table: "Albums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("68ed7234-494e-44e3-bce5-dd5322326a65"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 21, 15, 35, 28, 967, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Singers",
                keyColumn: "Id",
                keyValue: new Guid("ee841df3-532c-4a78-8dfd-9c3eac5c1d4e"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 21, 15, 35, 28, 967, DateTimeKind.Local).AddTicks(4934));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SingerPhoto",
                table: "Singers");

            migrationBuilder.DropColumn(
                name: "CoverPhoto",
                table: "Albums");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: new Guid("68ed7234-494e-44e3-bce5-dd5322326a65"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 21, 12, 23, 13, 955, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Singers",
                keyColumn: "Id",
                keyValue: new Guid("ee841df3-532c-4a78-8dfd-9c3eac5c1d4e"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 21, 12, 23, 13, 955, DateTimeKind.Local).AddTicks(6182));
        }
    }
}
