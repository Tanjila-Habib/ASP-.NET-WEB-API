using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfessioanlModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Professional_ProfessionalId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professional",
                table: "Professional");

            migrationBuilder.RenameTable(
                name: "Professional",
                newName: "Professionals");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professionals",
                table: "Professionals",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Professionals_ProfessionalId",
                table: "Appointments",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Professionals_ProfessionalId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professionals",
                table: "Professionals");

            migrationBuilder.RenameTable(
                name: "Professionals",
                newName: "Professional");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professional",
                table: "Professional",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Professional_ProfessionalId",
                table: "Appointments",
                column: "ProfessionalId",
                principalTable: "Professional",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
