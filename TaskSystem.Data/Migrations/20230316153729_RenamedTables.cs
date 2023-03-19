using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Staff_ReporteeId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Staff_SupervisorId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemsStatus_StatusId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemsStatus_TaskItemStatusEntityId",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItemsStatus",
                table: "TaskItemsStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems");

            migrationBuilder.RenameTable(
                name: "TaskItemsStatus",
                newName: "Status");

            migrationBuilder.RenameTable(
                name: "TaskItems",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_TaskItemStatusEntityId",
                table: "Tasks",
                newName: "IX_Tasks_TaskItemStatusEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_SupervisorId",
                table: "Tasks",
                newName: "IX_Tasks_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_StatusId",
                table: "Tasks",
                newName: "IX_Tasks_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_ReporteeId",
                table: "Tasks",
                newName: "IX_Tasks_ReporteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskItemId",
                table: "Comments",
                column: "TaskItemId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks",
                column: "ReporteeId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks",
                column: "SupervisorId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_TaskItemStatusEntityId",
                table: "Tasks",
                column: "TaskItemStatusEntityId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_TaskItemStatusEntityId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskItems");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "TaskItemsStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskItemStatusEntityId",
                table: "TaskItems",
                newName: "IX_TaskItems_TaskItemStatusEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_SupervisorId",
                table: "TaskItems",
                newName: "IX_TaskItems_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusId",
                table: "TaskItems",
                newName: "IX_TaskItems_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ReporteeId",
                table: "TaskItems",
                newName: "IX_TaskItems_ReporteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItemsStatus",
                table: "TaskItemsStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Staff_ReporteeId",
                table: "TaskItems",
                column: "ReporteeId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Staff_SupervisorId",
                table: "TaskItems",
                column: "SupervisorId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskItemsStatus_StatusId",
                table: "TaskItems",
                column: "StatusId",
                principalTable: "TaskItemsStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskItemsStatus_TaskItemStatusEntityId",
                table: "TaskItems",
                column: "TaskItemStatusEntityId",
                principalTable: "TaskItemsStatus",
                principalColumn: "Id");
        }
    }
}
