using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedCarModelTypos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellDate",
                table: "Cars");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PurchaseDate",
                table: "Cars",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LotDate",
                table: "Cars",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "SaleDate",
                table: "Cars",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LotDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "SellDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
