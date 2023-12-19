using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingerSong.Persistence.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SingerName = table.Column<string>(type: "TEXT", nullable: true),
                    SingerType = table.Column<int>(type: "INTEGER", nullable: false),
                    MusicStyle = table.Column<int>(type: "INTEGER", nullable: false),
                    SingerAbout = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RoleID = table.Column<Guid>(type: "TEXT", nullable: true),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: true),
                    TokenExpiredTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlbumName = table.Column<string>(type: "TEXT", nullable: true),
                    SongCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    SingerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Singers_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlbumID = table.Column<Guid>(type: "TEXT", nullable: false),
                    SongName = table.Column<string>(type: "TEXT", nullable: true),
                    SongWeight = table.Column<float>(type: "REAL", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsActive", "RoleTitle" },
                values: new object[] { new Guid("279b1e39-aca5-44db-aacb-ecd57ae4831e"), "This role is for standard users.", false, "User" });

            migrationBuilder.InsertData(
                table: "Singers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Location", "MusicStyle", "SingerAbout", "SingerName", "SingerType", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("ee841df3-532c-4a78-8dfd-9c3eac5c1d4e"), null, new DateTime(2023, 6, 21, 12, 23, 13, 955, DateTimeKind.Local).AddTicks(6182), false, "USA", 16, "Metallica is an American heavy metal band. The band was formed in 1981 in Los Angeles by vocalist and guitarist James Hetfield and drummer Lars Ulrich, and has been based in San Francisco for most of its career.", "Metallica", 1, null, null });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "AlbumName", "CreatedBy", "CreatedDate", "IsActive", "SingerID", "SongCount", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("68ed7234-494e-44e3-bce5-dd5322326a65"), "Load", null, new DateTime(2023, 6, 21, 12, 23, 13, 955, DateTimeKind.Local).AddTicks(7275), false, new Guid("ee841df3-532c-4a78-8dfd-9c3eac5c1d4e"), 14, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "Password", "RefreshToken", "RoleID", "TokenExpiredTime" },
                values: new object[] { new Guid("9a82361b-7fe1-4155-a220-5a637fc60b46"), "johndoe@mail.com", false, "john123", null, new Guid("279b1e39-aca5-44db-aacb-ecd57ae4831e"), null });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumID", "IsActive", "SongName", "SongWeight" },
                values: new object[] { new Guid("54fa52b2-893d-4603-954f-348a12ad98b2"), new Guid("68ed7234-494e-44e3-bce5-dd5322326a65"), false, "Wasting my hate", 3.57f });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_SingerID",
                table: "Albums",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleTitle",
                table: "Roles",
                column: "RoleTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Singers_SingerName",
                table: "Singers",
                column: "SingerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Singers");
        }
    }
}
