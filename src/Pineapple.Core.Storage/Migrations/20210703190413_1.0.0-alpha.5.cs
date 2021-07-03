using Microsoft.EntityFrameworkCore.Migrations;

namespace Pineapple.Core.Storage.Migrations
{
    public partial class _100alpha5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImportant",
                schema: "pineapple",
                table: "ComponentVersions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImportant",
                schema: "pineapple",
                table: "ComponentVersions");
        }
    }
}
