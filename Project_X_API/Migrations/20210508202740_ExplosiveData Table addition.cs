using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_X_API.Migrations
{
    public partial class ExplosiveDataTableaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExplosiveData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: false),
                    Category = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true),
                    ManufacturersCountry = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true),
                    Caliber = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true),
                    ExplosivePurposeId = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true),
                    DetonatorTypeId = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    Material = table.Column<string>(type: "longtext", nullable: true),
                    Tier = table.Column<string>(type: "longtext", nullable: true),
                    Assembly = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplosiveData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExplosiveData");
        }
    }
}
