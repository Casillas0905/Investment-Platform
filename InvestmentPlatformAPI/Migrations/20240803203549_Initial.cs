using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InvestmentPlatform.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TastytradeEmail = table.Column<string>(type: "text", nullable: false),
                    TastytradePassword = table.Column<string>(type: "text", nullable: false),
                    TastytradeAccountNumber = table.Column<string>(type: "text", nullable: false),
                    AppPassword = table.Column<string>(type: "text", nullable: false),
                    AppUsername = table.Column<string>(type: "text", nullable: false),
                    AppEmail = table.Column<string>(type: "text", nullable: false),
                    AppName = table.Column<string>(type: "text", nullable: false),
                    AppLastname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
