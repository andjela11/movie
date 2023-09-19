using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Genre = table.Column<string>(type: "longtext", nullable: false),
                    ImdbURL = table.Column<string>(type: "longtext", nullable: true),
                    ImdbRating = table.Column<float>(type: "float", nullable: false),
                    Synopsis = table.Column<string>(type: "longtext", nullable: false),
                    Released = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ImdbRating", "ImdbURL", "Released", "Synopsis", "Title" },
                values: new object[] { 10, "Bogus.DataSets.Music,Bogus.DataSets.Music,Bogus.DataSets.Music", 7.4f, "Bogus.DataSets.Address,Bogus.DataSets.Address,Bogus.DataSets.Address", 2022, "Bogus.DataSets.Lorem", "Bogus.DataSets.Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
