using Microsoft.EntityFrameworkCore.Migrations;

namespace mis.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Users");
        }
    }
}
