using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedNavigationFromStatusEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusEntityId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusEntityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusEntityId",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusEntityId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusEntityId",
                table: "Tasks",
                column: "StatusEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusEntityId",
                table: "Tasks",
                column: "StatusEntityId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}
