using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dr.Infrastracture.Migrations
{
    public partial class AddTimeTableAndSifht : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeTableId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    TimeTableId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTimes_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 23, 18, 18, 8, 514, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 23, 18, 18, 8, 514, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 23, 18, 18, 8, 514, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TimeTableId",
                table: "Doctors",
                column: "TimeTableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTimes_TimeTableId",
                table: "ShiftTimes",
                column: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_TimeTables_TimeTableId",
                table: "Doctors",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_TimeTables_TimeTableId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "ShiftTimes");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_TimeTableId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TimeTableId",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 22, 11, 30, 52, 884, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 22, 11, 30, 52, 887, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 22, 11, 30, 52, 887, DateTimeKind.Local).AddTicks(4314));
        }
    }
}
