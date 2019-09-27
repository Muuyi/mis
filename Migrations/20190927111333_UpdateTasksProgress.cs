using Microsoft.EntityFrameworkCore.Migrations;

namespace mis.Migrations
{
    public partial class UpdateTasksProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TasksProgress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasksProgress_ApplicationUserId",
                table: "TasksProgress",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksProgress_AspNetUsers_ApplicationUserId",
                table: "TasksProgress",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksProgress_AspNetUsers_ApplicationUserId",
                table: "TasksProgress");

            migrationBuilder.DropIndex(
                name: "IX_TasksProgress_ApplicationUserId",
                table: "TasksProgress");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TasksProgress");
        }
    }
}
