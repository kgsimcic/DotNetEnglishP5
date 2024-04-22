using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlAndAvailableFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");
        }
    }
}
