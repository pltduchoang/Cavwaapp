using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAVWAApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateImageforevent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppEvent");
        }
    }
}
