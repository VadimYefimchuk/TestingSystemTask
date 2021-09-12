using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Data.Migrations
{
    public partial class AddedImageUrlFieldToTestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tests");
        }
    }
}
