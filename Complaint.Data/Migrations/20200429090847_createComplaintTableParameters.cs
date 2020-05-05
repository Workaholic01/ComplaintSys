using Microsoft.EntityFrameworkCore.Migrations;

namespace Complaint.Data.Migrations
{
    public partial class createComplaintTableParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Complaint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Complaint");
        }
    }
}
