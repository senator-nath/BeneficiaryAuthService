using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeneficiaryService.Persistence.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryAccountNumber",
                table: "Beneficiary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryAccountNumber",
                table: "Beneficiary");
        }
    }
}
