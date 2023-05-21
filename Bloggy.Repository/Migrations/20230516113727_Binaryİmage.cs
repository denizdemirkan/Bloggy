using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggy.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Binaryİmage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImage",
                table: "Blogs",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Blogs");
        }
    }
}
