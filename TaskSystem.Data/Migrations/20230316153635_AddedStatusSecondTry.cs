using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusSecondTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntity_TaskItems_TaskItemId",
                table: "CommentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_StatusId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_TaskItemStatusEntityId",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItemStatusEntity",
                table: "TaskItemStatusEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity");

            migrationBuilder.RenameTable(
                name: "TaskItemStatusEntity",
                newName: "TaskItemsStatus");

            migrationBuilder.RenameTable(
                name: "CommentEntity",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntity_TaskItemId",
                table: "Comments",
                newName: "IX_Comments_TaskItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItemsStatus",
                table: "TaskItemsStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments");

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
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "TaskItemsStatus",
                newName: "TaskItemStatusEntity");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TaskItemId",
                table: "CommentEntity",
                newName: "IX_CommentEntity_TaskItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItemStatusEntity",
                table: "TaskItemStatusEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntity_TaskItems_TaskItemId",
                table: "CommentEntity",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_StatusId",
                table: "TaskItems",
                column: "StatusId",
                principalTable: "TaskItemStatusEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_TaskItemStatusEntityId",
                table: "TaskItems",
                column: "TaskItemStatusEntityId",
                principalTable: "TaskItemStatusEntity",
                principalColumn: "Id");
        }
    }
}
