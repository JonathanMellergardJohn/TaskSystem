using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_TaskItemStatusEntityId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskItemStatusEntityId",
                table: "Tasks",
                newName: "StatusEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskItemStatusEntityId",
                table: "Tasks",
                newName: "IX_Tasks_StatusEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusEntityId",
                table: "Tasks",
                column: "StatusEntityId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusEntityId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "StatusEntityId",
                table: "Tasks",
                newName: "TaskItemStatusEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusEntityId",
                table: "Tasks",
                newName: "IX_Tasks_TaskItemStatusEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_TaskItemStatusEntityId",
                table: "Tasks",
                column: "TaskItemStatusEntityId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}
