using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProApiFull.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateededede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpdatedOrDeleted",
                table: "ImageProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdatedOrDeleted",
                table: "ImageProducts");
        }
    }
}
