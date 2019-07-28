using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolsAdmin.Domain.Migrations
{
    public partial class includingvalidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Classrooms",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classrooms",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Classrooms",
                newName: "Active");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classrooms",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }
    }
}
