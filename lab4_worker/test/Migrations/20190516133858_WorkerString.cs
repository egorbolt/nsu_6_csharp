using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class WorkerString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerNumber",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "WorkerString",
                table: "Workers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerString",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "WorkerNumber",
                table: "Workers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
