using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCodeFirst.Migrations
{
    public partial class mg7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteWeb",
                table: "Hotel",
                newName: "SiteW");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Hotel",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteW",
                table: "Hotel",
                newName: "SiteWeb");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
