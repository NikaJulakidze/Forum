using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class RatingPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RatingPoints",
                table: "Questions",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 286, DateTimeKind.Local).AddTicks(8284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 420, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.AlterColumn<int>(
                name: "RatingPoints",
                table: "Answers",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 288, DateTimeKind.Local).AddTicks(5761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 422, DateTimeKind.Local).AddTicks(1840));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RatingPoints",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 420, DateTimeKind.Local).AddTicks(4971),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 286, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.AlterColumn<int>(
                name: "RatingPoints",
                table: "Answers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 422, DateTimeKind.Local).AddTicks(1840),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 288, DateTimeKind.Local).AddTicks(5761));
        }
    }
}
