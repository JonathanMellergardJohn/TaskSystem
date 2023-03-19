using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsAdminBoolToStaffEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Staff");
        }
    }
}
