using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmAnmeldelseApi.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direktør",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuldenavn = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instrukt__3214EC278815F81A", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Plakat = table.Column<byte[]>(type: "image", nullable: false),
                    Synopse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Aldersgrænse = table.Column<int>(type: "int", nullable: false),
                    Udgivelsesdato = table.Column<DateOnly>(type: "date", nullable: false),
                    Spilletid = table.Column<TimeOnly>(type: "time", nullable: false),
                    Gennemsnitsanmeldelse = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Film__3214EC2746F236D8", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Forfatter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuldenavn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Forfatte__3214EC27D59A45F7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genre__F1410CF224D9D7C1", x => x.Genre);
                });

            migrationBuilder.CreateTable(
                name: "Komponist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuldenavn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Komponis__3214EC2782083175", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuldenavn = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producer__3214EC27038A45DF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skuespiller",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuldenavn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skuespil__3214EC27680C70A5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brugernavn = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Billede = table.Column<byte[]>(type: "image", nullable: true),
                    Adgangskode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Oprettelsesdato = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3214EC2750F10E59", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilmDirektør",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    DirektørID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDirektør", x => new { x.FilmID, x.DirektørID });
                    table.ForeignKey(
                        name: "FK_FilmDirektør_Direktør_DirektørID",
                        column: x => x.DirektørID,
                        principalTable: "Direktør",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FilmDirektør_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rolle",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    Rollenavn = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rolle__362D0EEF34CB2A50", x => new { x.FilmID, x.Rollenavn });
                    table.ForeignKey(
                        name: "FK__Rolle__FilmID__5DCAEF64",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FilmForfatter",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ForfatterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmForfatter", x => new { x.FilmID, x.ForfatterID });
                    table.ForeignKey(
                        name: "FK_FilmForfatter_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FilmForfatter_Forfatter_ForfatterID",
                        column: x => x.ForfatterID,
                        principalTable: "Forfatter",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmID, x.Genre });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_Genre",
                        column: x => x.Genre,
                        principalTable: "Genre",
                        principalColumn: "Genre");
                });

            migrationBuilder.CreateTable(
                name: "FilmKomponist",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    KomponistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmKomponist", x => new { x.FilmID, x.KomponistID });
                    table.ForeignKey(
                        name: "FK_FilmKomponist_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FilmKomponist_Komponist_KomponistID",
                        column: x => x.KomponistID,
                        principalTable: "Komponist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FilmProducer",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ProducerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmProducer", x => new { x.FilmID, x.ProducerID });
                    table.ForeignKey(
                        name: "FK_FilmProducer_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FilmProducer_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Anmeldelse",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    AnmelderID = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: true),
                    Begrundelse = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Bedømmelse = table.Column<int>(type: "int", nullable: false),
                    Anmeldsdato = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Anmeldel__20E4DA6C24B6FAD6", x => new { x.FilmID, x.AnmelderID });
                    table.ForeignKey(
                        name: "FK__Anmeldels__Anmel__5441852A",
                        column: x => x.AnmelderID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Anmeldels__FilmI__5535A963",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SkuespillerRolle",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    Rollenavn = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: false),
                    SkuespillerID = table.Column<int>(type: "int", nullable: false),
                    RolleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skuespil__CA96AC10E2A1A6B6", x => new { x.FilmID, x.Rollenavn, x.SkuespillerID });
                    table.ForeignKey(
                        name: "FK__Skuespill__Skues__5EBF139D",
                        column: x => x.SkuespillerID,
                        principalTable: "Skuespiller",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__SkuespillerRolle__5FB337D6",
                        columns: x => new { x.FilmID, x.Rollenavn },
                        principalTable: "Rolle",
                        principalColumns: new[] { "FilmID", "Rollenavn" });
                });

            migrationBuilder.CreateTable(
                name: "Kommentar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kommentar = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    kommentatorID = table.Column<int>(type: "int", nullable: false),
                    AnmeldelsensAnmelderID = table.Column<int>(type: "int", nullable: false),
                    AnmeldelsensFilmID = table.Column<int>(type: "int", nullable: false),
                    KommentarDato = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kommenta__3214EC2776F61ECF", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Kommentar__5BE2A6F2",
                        columns: x => new { x.AnmeldelsensAnmelderID, x.AnmeldelsensFilmID },
                        principalTable: "Anmeldelse",
                        principalColumns: new[] { "FilmID", "AnmelderID" });
                    table.ForeignKey(
                        name: "FK__Kommentar__komme__5CD6CB2B",
                        column: x => x.kommentatorID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anmeldelse_AnmelderID",
                table: "Anmeldelse",
                column: "AnmelderID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmDirektør_DirektørID",
                table: "FilmDirektør",
                column: "DirektørID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmForfatter_ForfatterID",
                table: "FilmForfatter",
                column: "ForfatterID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_Genre",
                table: "FilmGenre",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_FilmKomponist_KomponistID",
                table: "FilmKomponist",
                column: "KomponistID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmProducer_ProducerID",
                table: "FilmProducer",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Genre__F1410CF3E230D5EB",
                table: "Genre",
                column: "Genre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_AnmeldelsensAnmelderID_AnmeldelsensFilmID",
                table: "Kommentar",
                columns: new[] { "AnmeldelsensAnmelderID", "AnmeldelsensFilmID" });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_kommentatorID",
                table: "Kommentar",
                column: "kommentatorID");

            migrationBuilder.CreateIndex(
                name: "IX_SkuespillerRolle_SkuespillerID",
                table: "SkuespillerRolle",
                column: "SkuespillerID");

            migrationBuilder.CreateIndex(
                name: "UQ__User__6BE4ADA0CFE63EE7",
                table: "User",
                column: "Brugernavn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmDirektør");

            migrationBuilder.DropTable(
                name: "FilmForfatter");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "FilmKomponist");

            migrationBuilder.DropTable(
                name: "FilmProducer");

            migrationBuilder.DropTable(
                name: "Kommentar");

            migrationBuilder.DropTable(
                name: "SkuespillerRolle");

            migrationBuilder.DropTable(
                name: "Direktør");

            migrationBuilder.DropTable(
                name: "Forfatter");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Komponist");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Anmeldelse");

            migrationBuilder.DropTable(
                name: "Skuespiller");

            migrationBuilder.DropTable(
                name: "Rolle");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
