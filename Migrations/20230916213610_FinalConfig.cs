using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrgAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class FinalConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastPasswordChange",
                table: "Users",
                newName: "LastPasswordChangeDate");

            migrationBuilder.AlterColumn<byte>(
                name: "startPageMode",
                table: "Users",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastPasswordChangeDate",
                table: "Users",
                newName: "LastPasswordChange");

            migrationBuilder.AlterColumn<short>(
                name: "startPageMode",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
