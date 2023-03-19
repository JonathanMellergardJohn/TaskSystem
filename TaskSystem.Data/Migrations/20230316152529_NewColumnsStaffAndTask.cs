using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnsStaffAndTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Staff");
        }
    }
}
