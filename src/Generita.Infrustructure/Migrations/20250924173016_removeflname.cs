using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class removeflname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Authors",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
            migrationBuilder.Sql(@"
            UPDATE ""Authors""
            SET ""Name"" = ""Name_firtName"" || ' ' || ""Name_LastName"";
        ");
            migrationBuilder.DropColumn(
                name: "Name_firtName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Name_LastName",
                table: "Authors");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                table: "Authors",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_firtName",
                table: "Authors",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
            migrationBuilder.Sql(@"
            UPDATE ""Authors""
            SET ""Name_firtName"" = split_part(""Name"", ' ', 1),
                ""Name_LastName"" = split_part(""Name"", ' ', 2);
        ");
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Authors");
        }
    }
}
