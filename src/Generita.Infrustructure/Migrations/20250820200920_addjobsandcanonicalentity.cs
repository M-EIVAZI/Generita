using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    public partial class addjobsandcanonicalentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeClasses",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "Songs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Music",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityInstancesId",
                table: "Entity",
                type: "uuid",
                nullable: false,
                defaultValue: Guid.Empty); // 00000000-... 

            // ابتدا جدول CanonicalEntity بساز
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

            // رکورد پیش‌فرض برای جلوگیری از خطای FK اضافه کن
            migrationBuilder.InsertData(
                table: "CanonicalEntity",
                columns: new[] { "Id", "Type" },
                values: new object[] { Guid.Empty, "Default" });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CanonicalEntityVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CanonicalEntityId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "IX_CanonicalEntityVariant_CanonicalEntityId",
                table: "CanonicalEntityVariant",
                column: "CanonicalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AuthorId",
                table: "Jobs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_BookId",
                table: "Jobs",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_CanonicalEntity_EntityInstancesId",
                table: "Entity",
                column: "EntityInstancesId",
                principalTable: "CanonicalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_CanonicalEntity_EntityInstancesId",
                table: "Entity");

            migrationBuilder.DropTable(
                name: "CanonicalEntityVariant");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "CanonicalEntity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_EntityInstancesId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "AgeClasses",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Music",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "EntityInstancesId",
                table: "Entity");
        }
    }
}
