using Microsoft.EntityFrameworkCore.Migrations;

namespace mis.Migrations
{
    public partial class UpdatemeetingProfressDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Metric",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeetingProgress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metric",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeetingProgress");
        }
    }
}
