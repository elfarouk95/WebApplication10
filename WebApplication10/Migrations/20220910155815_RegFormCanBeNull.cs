using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class RegFormCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_RegForms_RegFormId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "RegFormId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RegForms_RegFormId",
                table: "Students",
                column: "RegFormId",
                principalTable: "RegForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_RegForms_RegFormId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "RegFormId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RegForms_RegFormId",
                table: "Students",
                column: "RegFormId",
                principalTable: "RegForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
