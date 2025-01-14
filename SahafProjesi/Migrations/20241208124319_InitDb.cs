using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SahafProjesi.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 1,
                column: "KitapOzeti",
                value: "Simyacı, Paulo Coelho'nun, kişisel efsaneyi takip ederek mutluluğu ve anlamı bulma yolculuğunu anlatan bir roman.");

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimYili", "BaskiSayisi", "Fiyat", "KapakResmi", "KategoriID", "KitapAdi", "KitapOzeti", "KullaniciID", "YayineviID", "YazarID" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7500, 60m, "1984.jpg", 3, "1984", "George Orwell'in distopik bir geleceği anlattığı çarpıcı roman.", 2, 2, 2 },
                    { 3, new DateTime(2018, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000, 45m, "kucukprens.jpg", 1, "Küçük Prens", "Antoine de Saint-Exupéry'nin çocuklar ve yetişkinler için felsefi     bir             başyapıtı.", 2, 3, 3 },
                    { 4, new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6500, 70m, "sefiller.jpg", 3, "Sefiller", "Victor Hugo'nun adalet, aşk ve fedakarlık üzerine unutulmaz   eseri.", 1, 4, 4 },
                    { 5, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000, 80m, "sucveceza.jpg", 3, "Suç ve Ceza", "Fyodor Dostoyevski'nin, ahlak ve vicdan üzerine derin bir         incelemesi.", 2, 3, 2 },
                    { 6, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000, 85m, "harrypotter1.jpg", 4, "Harry Potter ve Felsefe Taşı", "J.K. Rowling'in büyücülük dünyasına giriş yaptığı ilk kitap.", 1, 1, 2 },
                    { 7, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8000, 50m, "ucurtmaavcisi.jpg", 2, "Uçurtma Avcısı", "Khaled Hosseini'nin dostluk ve ihanet temalarını işlediği     unutulmaz       roman.", 1, 4, 3 },
                    { 8, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000, 55m, "beyazzambaklar.jpg", 2, "Beyaz Zambaklar Ülkesinde", "Grigory Petrov'un toplumsal gelişimi anlatan klasik eseri.", 2, 1, 1 },
                    { 9, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000, 40m, "sekerportakali.jpg", 1, "Şeker Portakalı", "José Mauro de Vasconcelos'un çocukluk üzerine etkileyici  hikayesi.", 1, 3, 2 },
                    { 10, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8500, 45m, "hayvanciftligi.jpg", 3, "Hayvan Çiftliği", "George Orwell'in, toplumsal eleştirilerle dolu hiciv eseri.", 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 1,
                column: "KitapOzeti",
                value: "Simyacı, Paulo Coelho'nun, kişisel efsaneyi takip ederek mutluluğu ve anlamı bulma yolculuğunu anlatan, genç bir çobanın hayallerini gerçekleştirme çabalarını konu alan bir romandır.");
        }
    }
}
