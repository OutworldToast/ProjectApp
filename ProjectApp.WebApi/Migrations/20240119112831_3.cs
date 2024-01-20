using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BedrijfId",
                table: "Onderzoeken",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_BedrijfId",
                table: "Onderzoeken",
                column: "BedrijfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Onderzoeken_AspNetUsers_BedrijfId",
                table: "Onderzoeken",
                column: "BedrijfId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onderzoeken_AspNetUsers_BedrijfId",
                table: "Onderzoeken");

            migrationBuilder.DropIndex(
                name: "IX_Onderzoeken_BedrijfId",
                table: "Onderzoeken");

            migrationBuilder.DropColumn(
                name: "BedrijfId",
                table: "Onderzoeken");
        }
    }
}
