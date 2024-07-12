using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarNumberGuideApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RegionNumbers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionNumbers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RegionNumbers_Regions_Code",
                        column: x => x.Code,
                        principalTable: "Regions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationNumbers",
                columns: table => new
                {
                    SymbolicCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionNumberCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationNumbers", x => x.SymbolicCode);
                    table.ForeignKey(
                        name: "FK_RegistrationNumbers_RegionNumbers_RegionNumberCode",
                        column: x => x.RegionNumberCode,
                        principalTable: "RegionNumbers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationNumbers_RegionNumberCode",
                table: "RegistrationNumbers",
                column: "RegionNumberCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationNumbers");

            migrationBuilder.DropTable(
                name: "RegionNumbers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
