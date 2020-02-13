using Microsoft.EntityFrameworkCore.Migrations;

namespace CeleryMisfortune.DataAccess.Migrations
{
    public partial class ADDattr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentLife",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Energy",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelExp",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LifeRemark",
                table: "PlayerStates",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxLifeTime",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "PlayerStates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StateLevel",
                table: "PlayerStates",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttrName",
                table: "PlayerAttributes",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttrValue",
                table: "PlayerAttributes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttributeType",
                table: "PlayerAttributes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLife",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "Energy",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "LevelExp",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "LifeRemark",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "MaxLifeTime",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "StateLevel",
                table: "PlayerStates");

            migrationBuilder.DropColumn(
                name: "AttrName",
                table: "PlayerAttributes");

            migrationBuilder.DropColumn(
                name: "AttrValue",
                table: "PlayerAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeType",
                table: "PlayerAttributes");
        }
    }
}
