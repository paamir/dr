using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dr.Infrastracture.Migrations
{
    public partial class AddRecoverCodeTable : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecoverCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoverCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecoverCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 16, 13, 35, 412, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 16, 13, 35, 414, DateTimeKind.Local).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 16, 13, 35, 414, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.CreateIndex(
                name: "IX_RecoverCodes_UserId",
                table: "RecoverCodes",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecoverCodes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 11, 39, 39, 964, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 11, 39, 39, 966, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 19, 11, 39, 39, 966, DateTimeKind.Local).AddTicks(5208));
        }
    }
}
