using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReporteeToNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks",
                column: "ReporteeId",
                principalTable: "Staff",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Staff_ReporteeId",
                table: "Tasks",
                column: "ReporteeId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
