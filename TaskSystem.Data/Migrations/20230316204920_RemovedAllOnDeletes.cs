using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAllOnDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks",
                column: "SupervisorId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks",
                column: "SupervisorId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
