using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class asdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courches",
                columns: table => new
                {
                    CourcesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourcesTiltle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourcesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courcesimageurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourcesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courches", x => x.CourcesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courches");
        }
    }
}
