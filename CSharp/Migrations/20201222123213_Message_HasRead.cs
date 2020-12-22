using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class Message_HasRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasRead",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRead",
                table: "Messages");
        }
    }
}
