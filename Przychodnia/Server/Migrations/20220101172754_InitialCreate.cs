using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przychodnia.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Successful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Doktor" },
                    { 3, "Pacjent" }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "Date", "Description", "Duration", "Name", "Paid", "Successful" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Badanie Rozwojowe", 3, "Badanie", true, true },
                    { 2, new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Badanie Rozwojowe1", 4, "Badanie1", true, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name", "PhotoPath", "RoleID", "Surname" },
                values: new object[] { 99574836547L, "Cezary", "Images/Cezary.png", 3, "Muza" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name", "PhotoPath", "RoleID", "Surname" },
                values: new object[] { 99768496534L, "Wiktoria", "Images/Wiktoria.png", 2, "Tak" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name", "PhotoPath", "RoleID", "Surname" },
                values: new object[] { 995213523765L, "Marcel", "Images/Marcel.png", 1, "Kowal" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
