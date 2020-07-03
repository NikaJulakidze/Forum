using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class UsersActionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 16, 9, 51, 134, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 385, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 2, 16, 9, 51, 136, DateTimeKind.Local).AddTicks(1484),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 387, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.CreateTable(
                name: "UsersActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 2, 16, 9, 51, 136, DateTimeKind.Local).AddTicks(5480)),
                    IpAddress = table.Column<string>(nullable: true),
                    ActionType = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersActions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersActions_ApplicationUserId",
                table: "UsersActions",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersActions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 385, DateTimeKind.Local).AddTicks(2091),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 16, 9, 51, 134, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 16, 21, 56, 11, 387, DateTimeKind.Local).AddTicks(2012),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 2, 16, 9, 51, 136, DateTimeKind.Local).AddTicks(1484));
        }
    }
}
