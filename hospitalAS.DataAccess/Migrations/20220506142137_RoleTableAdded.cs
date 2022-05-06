using Microsoft.EntityFrameworkCore.Migrations;

namespace hospitalAS.DataAccess.Migrations
{
    public partial class RoleTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Doctors",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RoleId",
                table: "Patients",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoleId",
                table: "Doctors",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Roles_RoleId",
                table: "Doctors",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Roles_RoleId",
                table: "Patients",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Roles_RoleId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Roles_RoleId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RoleId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RoleId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Doctors");
        }
    }
}
