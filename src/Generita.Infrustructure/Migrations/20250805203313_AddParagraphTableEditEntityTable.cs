using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParagraphTableEditEntityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Books_BookId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_SongId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_BookId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_SongId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Entity",
                newName: "ParagraphId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Entity",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Entity",
                newName: "MusicId");

            migrationBuilder.Sql(@"
    ALTER TABLE ""Plans""
    ALTER COLUMN ""Duration"" TYPE integer
    USING EXTRACT(DAY FROM ""Duration"")::int;
");


            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Entity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sample",
                table: "Entity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AgeClass = table.Column<string>(type: "text", nullable: false),
                    MusicSense = table.Column<string>(type: "text", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_MusicId",
                table: "Entity",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_BookId",
                table: "Paragraphs",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_SongId",
                table: "Paragraphs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity",
                column: "MusicId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Songs_MusicId",
                table: "Entity");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropIndex(
                name: "IX_Entity_MusicId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "sample",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Entity",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ParagraphId",
                table: "Entity",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "MusicId",
                table: "Entity",
                newName: "BookId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Plans",
                type: "interval",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string[]>(
                name: "Descriptions",
                table: "Entity",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_BookId",
                table: "Entity",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SongId",
                table: "Entity",
                column: "SongId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Books_BookId",
                table: "Entity",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Songs_SongId",
                table: "Entity",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
