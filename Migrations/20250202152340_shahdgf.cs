using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class shahdgf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courches");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursesTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CoursesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.CreateTable(
                name: "Courches",
                columns: table => new
                {
                    CourcesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourcesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourcesTiltle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourcesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courcesimageurl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courches", x => x.CourcesId);
                });
        }
    }
}
