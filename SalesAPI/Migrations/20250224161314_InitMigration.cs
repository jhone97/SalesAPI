using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignalRConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConnected = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "Id", "CompanyName", "EmailAddress", "IsConnected", "Name", "SignalRConnectionId" },
                values: new object[,]
                {
                    { 1, "Alkaalife", "khaled@alkaalife.com", false, "Khaled", "" },
                    { 2, "Alkaalife", "ali@alkaalife.com", false, "Ali", "" },
                    { 3, "Aljazerr", "escandar@aljazerr.com", false, "Escandar", "" },
                    { 4, "Jubali", "zaki@jubali.com", false, "Zaki", "" },
                    { 5, "Jubali", "naif@jubali.com", false, "Naif", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
