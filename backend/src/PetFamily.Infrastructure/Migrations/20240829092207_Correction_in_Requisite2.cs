using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction_in_Requisite2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requisites_list",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "details_list",
                table: "pets",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "details_list",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "requisites_list",
                table: "pets",
                type: "jsonb",
                nullable: true);
        }
    }
}
