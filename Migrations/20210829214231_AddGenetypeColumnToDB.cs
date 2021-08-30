using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonatorBackEndAspNetCoreApi.Migrations
{
    public partial class AddGenetypeColumnToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genetype",
                table: "BloodDonators",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genetype",
                table: "BloodDonators");
        }
    }
}
