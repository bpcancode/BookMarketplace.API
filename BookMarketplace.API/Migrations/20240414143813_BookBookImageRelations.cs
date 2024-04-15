using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMarketplace.API.Migrations
{
    /// <inheritdoc />
    public partial class BookBookImageRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "BookImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Mime",
                table: "BookImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "BookImages");

            migrationBuilder.DropColumn(
                name: "Mime",
                table: "BookImages");
        }
    }
}
