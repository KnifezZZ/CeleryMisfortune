using Microsoft.EntityFrameworkCore.Migrations;

namespace CeleryMisfortune.DataAccess.Migrations
{
    public partial class addalive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "PlayerInfos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "PlayerInfos");
        }
    }
}
