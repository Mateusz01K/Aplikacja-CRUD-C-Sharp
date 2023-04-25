using Microsoft.EntityFrameworkCore.Migrations;
namespace Projekt.Migrations
{
    public class AddIsReturnedColumnToRentalTable:Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "Rental",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "Rental");
        }
    }
}
