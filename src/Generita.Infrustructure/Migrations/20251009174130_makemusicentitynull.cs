using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class makemusicentitynull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity");

            migrationBuilder.AlterColumn<Guid>(
                name: "MusicId",
                table: "Entity",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity",
                column: "MusicId",
                principalTable: "Songs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity");

            migrationBuilder.AlterColumn<Guid>(
                name: "MusicId",
                table: "Entity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity",
                column: "MusicId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
