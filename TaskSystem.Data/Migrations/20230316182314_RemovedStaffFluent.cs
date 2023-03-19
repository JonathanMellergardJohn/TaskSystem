using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStaffFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReporteeId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks",
                column: "ReporteeId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks",
                column: "SupervisorId",
                principalTable: "Staff",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_SupervisorId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReporteeId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
