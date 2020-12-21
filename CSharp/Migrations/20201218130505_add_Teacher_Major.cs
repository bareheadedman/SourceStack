using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class add_Teacher_Major : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Student",
                table: "TB_Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Major",
                table: "TB_Major");

            migrationBuilder.RenameTable(
                name: "TB_Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "TB_Major",
                newName: "Majors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Majors",
                table: "Majors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Majors",
                table: "Majors");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "TB_Student");

            migrationBuilder.RenameTable(
                name: "Majors",
                newName: "TB_Major");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Student",
                table: "TB_Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Major",
                table: "TB_Major",
                column: "Id");
        }
    }
}
