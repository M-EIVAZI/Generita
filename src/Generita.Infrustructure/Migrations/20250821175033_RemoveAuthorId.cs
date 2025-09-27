using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Authors_AuthorId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_AuthorId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Entity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Entity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_AuthorId",
                table: "Entity",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Authors_AuthorId",
                table: "Entity",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
