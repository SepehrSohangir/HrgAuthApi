using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrgAuthApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    GroupCode = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.GroupCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<short>(type: "smallint", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PukCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PID = table.Column<int>(type: "int", nullable: true),
                    startPageMode = table.Column<short>(type: "smallint", nullable: false),
                    UserWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisableUser = table.Column<bool>(type: "bit", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    usrPasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMustChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    LastPasswordChange = table.Column<int>(type: "int", nullable: true),
                    PTAC = table.Column<bool>(type: "bit", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.UserId, x.CompanyID });
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "UserGroups",
                        principalColumn: "GroupCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupCode",
                table: "Users",
                column: "GroupCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
