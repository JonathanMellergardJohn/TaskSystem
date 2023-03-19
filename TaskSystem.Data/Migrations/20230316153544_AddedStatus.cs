using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskItemStatusEntityId",
                table: "TaskItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskItemStatusEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItemStatusEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_StatusId",
                table: "TaskItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskItemStatusEntityId",
                table: "TaskItems",
                column: "TaskItemStatusEntityId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_StatusId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskItemStatusEntity_TaskItemStatusEntityId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "TaskItemStatusEntity");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_StatusId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_TaskItemStatusEntityId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "TaskItemStatusEntityId",
                table: "TaskItems");
        }
    }
}
