using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SahafProjesi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Yayinevleri",
                columns: table => new
                {
                    YayineviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayineviAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinevleri", x => x.YayineviID);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    YazarSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "money", nullable: true),
                    BasimYili = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaskiSayisi = table.Column<int>(type: "int", nullable: false),
                    KitapOzeti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KapakResmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YazarID = table.Column<int>(type: "int", nullable: true),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    YayineviID = table.Column<int>(type: "int", nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID");
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID");
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yayinevleri_YayineviID",
                        column: x => x.YayineviID,
                        principalTable: "Yayinevleri",
                        principalColumn: "YayineviID");
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarID");
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriID", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Roman" },
                    { 2, "Makale" },
                    { 3, "Hikaye" },
                    { 4, "Felsefe" }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciID", "Ad", "KullaniciAdi", "Sifre", "Yas" },
                values: new object[,]
                {
                    { 1, "Rabia", "Rabia", "a730b6202d87981256d6b065cccf2786", 26 },
                    { 2, "Ayşe", "Ayse", "bb05576d9620bd292530d51112052df2", 30 }
                });

            migrationBuilder.InsertData(
                table: "Yayinevleri",
                columns: new[] { "YayineviID", "YayineviAdi" },
                values: new object[,]
                {
                    { 1, "Can" },
                    { 2, "İş Bankası" },
                    { 3, "Yapı Kredi Yayınları" },
                    { 4, "İthaki" }
                });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "YazarID", "YazarAdi", "YazarSoyadi" },
                values: new object[,]
                {
                    { 1, "Paulo", "Coelho" },
                    { 2, "Irvın", "Yalom" },
                    { 3, "Jose", "Saramago" },
                    { 4, "Stefan", "Zweig" }
                });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimYili", "BaskiSayisi", "Fiyat", "KapakResmi", "KategoriID", "KitapAdi", "KitapOzeti", "KullaniciID", "YayineviID", "YazarID" },
                values: new object[] { 1, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000, 50m, "simyaci.jpg", 2, "Simyacı", "Simyacı, Paulo Coelho'nun, kişisel efsaneyi takip ederek mutluluğu ve anlamı bulma yolculuğunu anlatan, genç bir çobanın hayallerini gerçekleştirme çabalarını konu alan bir romandır.", 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KategoriID",
                table: "Kitaplar",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KullaniciID",
                table: "Kitaplar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YayineviID",
                table: "Kitaplar",
                column: "YayineviID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarID",
                table: "Kitaplar",
                column: "YazarID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Yayinevleri");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
