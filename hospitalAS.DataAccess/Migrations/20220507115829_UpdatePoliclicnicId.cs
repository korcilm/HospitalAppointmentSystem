using Microsoft.EntityFrameworkCore.Migrations;

namespace hospitalAS.DataAccess.Migrations
{
    public partial class UpdatePoliclicnicId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Policlinics_PoliclinicId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PoliclinicId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Policlinics_PoliclinicId",
                table: "Users",
                column: "PoliclinicId",
                principalTable: "Policlinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Policlinics_PoliclinicId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PoliclinicId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Policlinics_PoliclinicId",
                table: "Users",
                column: "PoliclinicId",
                principalTable: "Policlinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
