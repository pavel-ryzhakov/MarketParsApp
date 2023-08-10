using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketParsApp.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "PowSuppUnits");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "PowSuppUnits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "PowSuppUnits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "PowSuppUnits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
