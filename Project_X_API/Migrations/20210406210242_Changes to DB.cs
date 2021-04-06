using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_X_API.Migrations
{
    public partial class ChangestoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_TokenValidation_TokenValidationId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_TokenValidationId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "TokenValidationId",
                table: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokenValidationId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_TokenValidationId",
                table: "Role",
                column: "TokenValidationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_TokenValidation_TokenValidationId",
                table: "Role",
                column: "TokenValidationId",
                principalTable: "TokenValidation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
