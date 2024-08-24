using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_MiddleName_renamed_json_data_To_Volunteer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "json_data",
                table: "volunteer",
                newName: "details_list");

            migrationBuilder.RenameColumn(
                name: "json_data",
                table: "pets",
                newName: "requisites_list");

            migrationBuilder.AddColumn<string>(
                name: "full_name_middle_name",
                table: "volunteer",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name_middle_name",
                table: "volunteer");

            migrationBuilder.RenameColumn(
                name: "details_list",
                table: "volunteer",
                newName: "json_data");

            migrationBuilder.RenameColumn(
                name: "requisites_list",
                table: "pets",
                newName: "json_data");
        }
    }
}
