using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiapweb2022.core.Migrations
{
    public partial class AddUserNameToTokenStories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TokensStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TokensStores");
        }
    }
}
