using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarNumberGuideApp.Migrations
{
    /// <inheritdoc />
    public partial class DbEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionNumbers_Regions_Code",
                table: "RegionNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationNumbers_RegionNumbers_RegionNumberCode",
                table: "RegistrationNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationNumbers",
                table: "RegistrationNumbers");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationNumbers_RegionNumberCode",
                table: "RegistrationNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionNumbers",
                table: "RegionNumbers");

            migrationBuilder.DropColumn(
                name: "RegionNumberCode",
                table: "RegistrationNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "SymbolicCode",
                table: "RegistrationNumbers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RegistrationNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RegionNumberId",
                table: "RegistrationNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "RegionNumbers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RegionNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "RegionNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationNumbers",
                table: "RegistrationNumbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionNumbers",
                table: "RegionNumbers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationNumbers_RegionNumberId",
                table: "RegistrationNumbers",
                column: "RegionNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionNumbers_RegionId",
                table: "RegionNumbers",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionNumbers_Regions_RegionId",
                table: "RegionNumbers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationNumbers_RegionNumbers_RegionNumberId",
                table: "RegistrationNumbers",
                column: "RegionNumberId",
                principalTable: "RegionNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegionNumbers_Regions_RegionId",
                table: "RegionNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationNumbers_RegionNumbers_RegionNumberId",
                table: "RegistrationNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationNumbers",
                table: "RegistrationNumbers");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationNumbers_RegionNumberId",
                table: "RegistrationNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionNumbers",
                table: "RegionNumbers");

            migrationBuilder.DropIndex(
                name: "IX_RegionNumbers_RegionId",
                table: "RegionNumbers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RegistrationNumbers");

            migrationBuilder.DropColumn(
                name: "RegionNumberId",
                table: "RegistrationNumbers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RegionNumbers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "RegionNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "SymbolicCode",
                table: "RegistrationNumbers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "RegionNumberCode",
                table: "RegistrationNumbers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "RegionNumbers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationNumbers",
                table: "RegistrationNumbers",
                column: "SymbolicCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionNumbers",
                table: "RegionNumbers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationNumbers_RegionNumberCode",
                table: "RegistrationNumbers",
                column: "RegionNumberCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RegionNumbers_Regions_Code",
                table: "RegionNumbers",
                column: "Code",
                principalTable: "Regions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationNumbers_RegionNumbers_RegionNumberCode",
                table: "RegistrationNumbers",
                column: "RegionNumberCode",
                principalTable: "RegionNumbers",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
