using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReSplash.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTagName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tag",
                newName: "TagName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "Tag",
                newName: "Name");
        }
    }
}
