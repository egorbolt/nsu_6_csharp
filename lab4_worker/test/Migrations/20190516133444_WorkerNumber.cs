using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class WorkerNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkerNumber",
                table: "Workers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerNumber",
                table: "Workers");
        }
    }
}
