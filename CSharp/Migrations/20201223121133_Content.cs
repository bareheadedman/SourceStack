using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class Content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Register_AuthorName",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Summary_SummaryId",
                table: "Problems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Problems",
                table: "Problems");

            migrationBuilder.RenameTable(
                name: "Problems",
                newName: "Contents");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_SummaryId",
                table: "Contents",
                newName: "IX_Contents_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_AuthorName",
                table: "Contents",
                newName: "IX_Contents_AuthorName");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemStatus",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Problem_Title",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sites",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suggest_Title",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "targetId",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_targetId",
                table: "Contents",
                column: "targetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Contents_targetId",
                table: "Contents",
                column: "targetId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Register_AuthorName",
                table: "Contents",
                column: "AuthorName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Summary_SummaryId",
                table: "Contents",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Contents_targetId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Register_AuthorName",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Summary_SummaryId",
                table: "Contents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_targetId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Problem_Title",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Sites",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Suggest_Title",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "targetId",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Problems");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_SummaryId",
                table: "Problems",
                newName: "IX_Problems_SummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_AuthorName",
                table: "Problems",
                newName: "IX_Problems_AuthorName");

            migrationBuilder.AlterColumn<int>(
                name: "ProblemStatus",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Problems",
                table: "Problems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Register_AuthorName",
                table: "Problems",
                column: "AuthorName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Summary_SummaryId",
                table: "Problems",
                column: "SummaryId",
                principalTable: "Summary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
