using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class TestindexUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 385, DateTimeKind.Local).AddTicks(2091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 286, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 387, DateTimeKind.Local).AddTicks(2012),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 288, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Title_Content",
                table: "Tags",
                columns: new[] { "Title", "Content" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tags_Title_Content",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 286, DateTimeKind.Local).AddTicks(8284),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 385, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 15, 23, 6, 39, 288, DateTimeKind.Local).AddTicks(5761),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 387, DateTimeKind.Local).AddTicks(2012));
        }
    }
}
