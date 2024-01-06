using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qlbhAPI.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Khoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Khoa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
