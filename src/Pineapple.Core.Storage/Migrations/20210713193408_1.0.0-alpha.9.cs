using Microsoft.EntityFrameworkCore.Migrations;

namespace Pineapple.Core.Storage.Migrations
{
    public partial class _100alpha9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackagesRepositoryPath",
                schema: "pineapple",
                table: "Components",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackagesRepositoryPath",
                schema: "pineapple",
                table: "Components");
        }
    }
}
