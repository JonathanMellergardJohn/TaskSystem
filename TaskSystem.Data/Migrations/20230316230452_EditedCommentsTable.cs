using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditedCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorRole",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorRole",
                table: "Comments");
        }
    }
}
