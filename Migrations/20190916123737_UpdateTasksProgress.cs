using Microsoft.EntityFrameworkCore.Migrations;

namespace mis.Migrations
{
    public partial class UpdateTasksProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TasksProgress_TasksId",
                table: "TasksProgress",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksProgress_Tasks_TasksId",
                table: "TasksProgress",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksProgress_Tasks_TasksId",
                table: "TasksProgress");

            migrationBuilder.DropIndex(
                name: "IX_TasksProgress_TasksId",
                table: "TasksProgress");
        }
    }
}
