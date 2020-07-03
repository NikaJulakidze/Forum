﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class fewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 420, DateTimeKind.Local).AddTicks(4971),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 14, 17, 51, 18, 667, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.AddColumn<int>(
                name: "RatingPoints",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 422, DateTimeKind.Local).AddTicks(1840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 14, 17, 51, 18, 669, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.AddColumn<int>(
                name: "RatingPoints",
                table: "Answers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingPoints",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "RatingPoints",
                table: "Answers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 14, 17, 51, 18, 667, DateTimeKind.Local).AddTicks(3587),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 420, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 14, 17, 51, 18, 669, DateTimeKind.Local).AddTicks(1286),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 4, 40, 422, DateTimeKind.Local).AddTicks(1840));
        }
    }
}