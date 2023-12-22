using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beperkingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beperkingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<int>(type: "int", nullable: false),
                    Emailadres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hulpmiddelen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benaderingsvoorkeur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onafhankelijk = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeperkingId = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onderzoeksdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tijdslimiet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoortOnderzoek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoeveelheidDeelnemers = table.Column<int>(type: "int", nullable: false),
                    Beloning = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Beperkingen_BeperkingId",
                        column: x => x.BeperkingId,
                        principalTable: "Beperkingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeperkingPanellid",
                columns: table => new
                {
                    BeperkingenId = table.Column<int>(type: "int", nullable: false),
                    PanelledenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeperkingPanellid", x => new { x.BeperkingenId, x.PanelledenId });
                    table.ForeignKey(
                        name: "FK_BeperkingPanellid_Beperkingen_BeperkingenId",
                        column: x => x.BeperkingenId,
                        principalTable: "Beperkingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeperkingPanellid_Gebruikers_PanelledenId",
                        column: x => x.PanelledenId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gebruiker1Id = table.Column<int>(type: "int", nullable: true),
                    Gebruiker2Id = table.Column<int>(type: "int", nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Gebruikers_Gebruiker1Id",
                        column: x => x.Gebruiker1Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Gebruikers_Gebruiker2Id",
                        column: x => x.Gebruiker2Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voogden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanellidId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<int>(type: "int", nullable: false),
                    Emailadres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voogden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voogden_Gebruikers_PanellidId",
                        column: x => x.PanellidId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deelnames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanellidId = table.Column<int>(type: "int", nullable: false),
                    OnderzoekId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deelnames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deelnames_Gebruikers_PanellidId",
                        column: x => x.PanellidId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deelnames_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Berichten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    Inhoud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tijdstip = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berichten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Berichten_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeperkingPanellid_PanelledenId",
                table: "BeperkingPanellid",
                column: "PanelledenId");

            migrationBuilder.CreateIndex(
                name: "IX_Berichten_ChatId",
                table: "Berichten",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Gebruiker1Id",
                table: "Chats",
                column: "Gebruiker1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Gebruiker2Id",
                table: "Chats",
                column: "Gebruiker2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deelnames_OnderzoekId",
                table: "Deelnames",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Deelnames_PanellidId",
                table: "Deelnames",
                column: "PanellidId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_BeperkingId",
                table: "Onderzoeken",
                column: "BeperkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Voogden_PanellidId",
                table: "Voogden",
                column: "PanellidId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeperkingPanellid");

            migrationBuilder.DropTable(
                name: "Berichten");

            migrationBuilder.DropTable(
                name: "Deelnames");

            migrationBuilder.DropTable(
                name: "Voogden");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Beperkingen");
        }
    }
}
