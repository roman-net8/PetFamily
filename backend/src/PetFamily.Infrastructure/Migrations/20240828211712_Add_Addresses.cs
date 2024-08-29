using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Addresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "pets",
                newName: "street");

            migrationBuilder.AddColumn<string>(
                name: "appartment",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "house",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appartment",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "city",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "country",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "house",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "pets",
                newName: "address");
        }
    }
}
