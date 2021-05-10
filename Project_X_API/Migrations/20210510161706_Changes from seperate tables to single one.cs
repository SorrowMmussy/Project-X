using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_X_API.Migrations
{
    public partial class Changesfromseperatetablestosingleone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExplosivePurposeId",
                table: "ExplosiveData",
                newName: "ExplosivePurpose");

            migrationBuilder.RenameColumn(
                name: "DetonatorTypeId",
                table: "ExplosiveData",
                newName: "DetonatorType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExplosivePurpose",
                table: "ExplosiveData",
                newName: "ExplosivePurposeId");

            migrationBuilder.RenameColumn(
                name: "DetonatorType",
                table: "ExplosiveData",
                newName: "DetonatorTypeId");
        }
    }
}
