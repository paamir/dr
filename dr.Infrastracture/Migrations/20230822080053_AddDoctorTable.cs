using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dr.Infrastracture.Migrations
{
    public partial class AddDoctorTable : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 22, 11, 30, 52, 884, DateTimeKind.Local).AddTicks(8824));

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 22, 11, 30, 52, 887, DateTimeKind.Local).AddTicks(4296));

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 22, 11, 30, 52, 887, DateTimeKind.Local).AddTicks(4314));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 19, 21, 38, 52, 783, DateTimeKind.Local).AddTicks(3578));

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 19, 21, 38, 52, 783, DateTimeKind.Local).AddTicks(8359));

            //migrationBuilder.UpdateData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    column: "CreationDate",
            //    value: new DateTime(2023, 8, 19, 21, 38, 52, 783, DateTimeKind.Local).AddTicks(8369));
        }
    }
}
