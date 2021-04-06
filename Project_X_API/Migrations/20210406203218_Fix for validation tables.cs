using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_X_API.Migrations
{
    public partial class Fixforvalidationtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersLoginInfo",
                table: "UsersLoginInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "UsersLoginInfo",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "User",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "User",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TokenValidationId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TokenValidation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenValidation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TokenValidation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_TokenValidationId",
                table: "Role",
                column: "TokenValidationId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenValidation_UserId",
                table: "TokenValidation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_TokenValidation_TokenValidationId",
                table: "Role",
                column: "TokenValidationId",
                principalTable: "TokenValidation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_TokenValidation_TokenValidationId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "TokenValidation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_TokenValidationId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TokenValidationId",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UsersLoginInfo");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersLoginInfo",
                table: "UsersLoginInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersPersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    MobilePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPersonalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPersonalInfo_UsersLoginInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersLoginInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPersonalInfo_UserId",
                table: "UsersPersonalInfo",
                column: "UserId",
                unique: true);
        }
    }
}
