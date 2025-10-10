using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Generita.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class removeimagepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // انتقال داده از ImagePath به Cover
            migrationBuilder.Sql("UPDATE \"Books\" SET \"Cover\" = \"ImagePath\" WHERE \"ImagePath\" IS NOT NULL AND \"ImagePath\" <> '';");

            // حالا ستون رو حذف کن
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // در حالت برگشت، ستون رو دوباره اضافه کن
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            // در حالت برگشت می‌تونیم برعکسش رو انجام بدیم (اختیاری)
            migrationBuilder.Sql("UPDATE \"Books\" SET \"ImagePath\" = \"Cover\" WHERE \"Cover\" IS NOT NULL AND \"Cover\" <> '';");
        }
    }
}
