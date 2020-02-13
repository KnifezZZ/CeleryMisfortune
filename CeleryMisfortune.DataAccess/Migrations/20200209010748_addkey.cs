using Microsoft.EntityFrameworkCore.Migrations;

namespace CeleryMisfortune.DataAccess.Migrations
{
    public partial class addkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FK_PlayerGuid",
                table: "PlayerAttributes",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_PlayerGuid",
                table: "PlayerAttributes");
        }
    }
}
