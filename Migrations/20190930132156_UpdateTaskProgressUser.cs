using Microsoft.EntityFrameworkCore.Migrations;

namespace mis.Migrations
{
    public partial class UpdateTaskProgressUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksProgress_AspNetUsers_ApplicationUserId",
                table: "TasksProgress");

            migrationBuilder.DropIndex(
                name: "IX_TasksProgress_ApplicationUserId",
                table: "TasksProgress");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "TasksProgress",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ProjectsProgress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Metric",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsProgress_ApplicationUserId",
                table: "ProjectsProgress",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsProgress_AspNetUsers_ApplicationUserId",
                table: "ProjectsProgress",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsProgress_AspNetUsers_ApplicationUserId",
                table: "ProjectsProgress");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsProgress_ApplicationUserId",
                table: "ProjectsProgress");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ProjectsProgress");

            migrationBuilder.DropColumn(
                name: "Metric",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "TasksProgress",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
