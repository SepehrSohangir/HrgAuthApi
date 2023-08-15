using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrgAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class addsignature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Signature",
                table: "Users",
                type: "varbinary(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Users");
        }
    }
}
