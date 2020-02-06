using Microsoft.EntityFrameworkCore.Migrations;

namespace CeleryMisfortune.DataAccess.Migrations
{
    public partial class adda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agility",
                table: "PlayerSpecials",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agility",
                table: "PlayerSpecials");
        }
    }
}
