using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Fixes_Column_To_Volunteer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "volunteer",
                newName: "full_name_last_name");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "volunteer",
                newName: "full_name_first_name");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "volunteer",
                newName: "json_data");

            migrationBuilder.RenameColumn(
                name: "Requisites",
                table: "pets",
                newName: "json_data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "full_name_last_name",
                table: "volunteer",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "full_name_first_name",
                table: "volunteer",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "json_data",
                table: "volunteer",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "json_data",
                table: "pets",
                newName: "Requisites");
        }
    }
}
