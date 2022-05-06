using Microsoft.EntityFrameworkCore.Migrations;

namespace hospitalAS.DataAccess.Migrations
{
    public partial class PrescriptionTAbleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsingCount = table.Column<int>(type: "int", nullable: false),
                    MedicamentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PrescriptionId",
                table: "Appointments",
                column: "PrescriptionId",
                unique: true,
                filter: "[PrescriptionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Prescriptions_PrescriptionId",
                table: "Appointments",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Prescriptions_PrescriptionId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PrescriptionId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "Appointments");
        }
    }
}
