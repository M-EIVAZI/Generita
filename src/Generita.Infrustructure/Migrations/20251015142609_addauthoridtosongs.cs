using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class addauthoridtosongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Songs",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Songs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AuthorId",
                table: "Songs",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Authors_AuthorId",
                table: "Songs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Authors_AuthorId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AuthorId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Songs");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Songs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);
        }
    }
}
