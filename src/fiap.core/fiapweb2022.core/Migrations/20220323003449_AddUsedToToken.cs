using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiapweb2022.core.Migrations
{
    public partial class AddUsedToToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Used",
                table: "TokensStores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Used",
                table: "TokensStores");
        }
    }
}
