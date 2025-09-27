using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityInstancesRemoveCanonicalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_CanonicalEntity_EntityInstancesId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity");

            migrationBuilder.DropTable(
                name: "CanonicalEntityVariant");

            migrationBuilder.DropTable(
                name: "CanonicalEntity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_EntityInstancesId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "EntityInstancesId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "ParagraphId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "sample",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "Music",
                table: "Songs",
                newName: "MusicSense");

            migrationBuilder.CreateTable(
                name: "EntityInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    sample = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParagraphId = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityInstances_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityInstances_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityInstances_EntityId",
                table: "EntityInstances",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityInstances_ParagraphId",
                table: "EntityInstances",
                column: "ParagraphId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityInstances");

            migrationBuilder.RenameColumn(
                name: "MusicSense",
                table: "Songs",
                newName: "Music");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityInstancesId",
                table: "Entity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParagraphId",
                table: "Entity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "CanonicalEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanonicalEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanonicalEntityVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CanonicalEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanonicalEntityVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CanonicalEntityVariant_CanonicalEntity_CanonicalEntityId",
                        column: x => x.CanonicalEntityId,
                        principalTable: "CanonicalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_EntityInstancesId",
                table: "Entity",
                column: "EntityInstancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParagraphId",
                table: "Entity",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_CanonicalEntityVariant_CanonicalEntityId",
                table: "CanonicalEntityVariant",
                column: "CanonicalEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_CanonicalEntity_EntityInstancesId",
                table: "Entity",
                column: "EntityInstancesId",
                principalTable: "CanonicalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Paragraphs_ParagraphId",
                table: "Entity",
                column: "ParagraphId",
                principalTable: "Paragraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
