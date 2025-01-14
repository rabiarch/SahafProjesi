using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahafProjesi.Models;

namespace SahafProjesi.Configurations
{
    public class Kitap_CFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.Fiyat).HasColumnType("money");

            builder.HasData
            (
                new Kitap
                {
                    KitapID = 1,
                    KitapAdi = "Simyacı",
                    Fiyat = 50,
                    KapakResmi = "simyaci.jpg",
                    BasimYili = new DateTime(2022, 10, 15),
                    KitapOzeti = "Simyacı, Paulo Coelho'nun, kişisel efsaneyi takip ederek mutluluğu ve anlamı bulma yolculuğunu anlatan bir roman.",
                    BaskiSayisi = 5000,
                    YazarID = 1,
                    KategoriID = 2,
                    YayineviID = 1,
                    KullaniciID = 1
                },

                new Kitap
                {
                    KitapID = 2,
                    KitapAdi = "1984",
                    Fiyat = 60,
                    KapakResmi = "1984.jpg",
                    BasimYili = new DateTime(2020, 5, 20),
                    KitapOzeti = "George Orwell'in distopik bir geleceği anlattığı çarpıcı roman.",
                    BaskiSayisi = 7500,
                    YazarID = 2,
                    KategoriID = 3,
                    YayineviID = 2,
                    KullaniciID = 2
                },

                new Kitap
                {
                    KitapID = 3,
                    KitapAdi = "Küçük Prens",
                    Fiyat = 45,
                    KapakResmi = "kucukprens.jpg",
                    BasimYili = new DateTime(2018, 3, 10),
                    KitapOzeti = "Antoine de Saint-Exupéry'nin çocuklar ve yetişkinler için felsefi     bir             başyapıtı.",
                    BaskiSayisi = 10000,
                    YazarID = 3,
                    KategoriID = 1,
                    YayineviID = 3,
                    KullaniciID = 2
                },
                
                new Kitap
                {
                    KitapID = 4,
                    KitapAdi = "Sefiller",
                    Fiyat = 70,
                    KapakResmi = "sefiller.jpg",
                    BasimYili = new DateTime(2019, 8, 25),
                    KitapOzeti = "Victor Hugo'nun adalet, aşk ve fedakarlık üzerine unutulmaz   eseri.",
                    BaskiSayisi = 6500,
                    YazarID = 4,
                    KategoriID = 3,
                    YayineviID = 4,
                    KullaniciID = 1
                },
                
                new Kitap
                {
                    KitapID = 5,
                    KitapAdi = "Suç ve Ceza",
                    Fiyat = 80,
                    KapakResmi = "sucveceza.jpg",
                    BasimYili = new DateTime(2021, 1, 30),
                    KitapOzeti = "Fyodor Dostoyevski'nin, ahlak ve vicdan üzerine derin bir         incelemesi.",
                    BaskiSayisi = 9000,
                    YazarID = 2,
                    KategoriID = 3,
                    YayineviID = 3,
                    KullaniciID = 2
                },
                
                new Kitap
                {
                    KitapID = 6,
                    KitapAdi = "Harry Potter ve Felsefe Taşı",
                    Fiyat = 85,
                    KapakResmi = "harrypotter1.jpg",
                    BasimYili = new DateTime(2022, 7, 21),
                    KitapOzeti = "J.K. Rowling'in büyücülük dünyasına giriş yaptığı ilk kitap.",
                    BaskiSayisi = 15000,
                    YazarID = 2,
                    KategoriID = 4,
                    YayineviID = 1,
                    KullaniciID = 1
                },
                
                new Kitap
                {
                    KitapID = 7,
                    KitapAdi = "Uçurtma Avcısı",
                    Fiyat = 50,
                    KapakResmi = "ucurtmaavcisi.jpg",
                    BasimYili = new DateTime(2019, 11, 10),
                    KitapOzeti = "Khaled Hosseini'nin dostluk ve ihanet temalarını işlediği     unutulmaz       roman.",
                    BaskiSayisi = 8000,
                    YazarID = 3,
                    KategoriID = 2,
                    YayineviID = 4,
                    KullaniciID = 1
                },
                
                new Kitap
                {
                    KitapID = 8,
                    KitapAdi = "Beyaz Zambaklar Ülkesinde",
                    Fiyat = 55,
                    KapakResmi = "beyazzambaklar.jpg",
                    BasimYili = new DateTime(2020, 9, 15),
                    KitapOzeti = "Grigory Petrov'un toplumsal gelişimi anlatan klasik eseri.",
                    BaskiSayisi = 5000,
                    YazarID = 1,
                    KategoriID = 2,
                    YayineviID = 1,
                    KullaniciID = 2
                },
                
                new Kitap
                {
                    KitapID = 9,
                    KitapAdi = "Şeker Portakalı",
                    Fiyat = 40,
                    KapakResmi = "sekerportakali.jpg",
                    BasimYili = new DateTime(2021, 6, 5),
                    KitapOzeti = "José Mauro de Vasconcelos'un çocukluk üzerine etkileyici  hikayesi.",
                    BaskiSayisi = 12000,
                    YazarID = 2,
                    KategoriID = 1,
                    YayineviID = 3,
                    KullaniciID = 1
                },
                
                new Kitap
                {
                    KitapID = 10,
                    KitapAdi = "Hayvan Çiftliği",
                    Fiyat = 45,
                    KapakResmi = "hayvanciftligi.jpg",
                    BasimYili = new DateTime(2018, 4, 1),
                    KitapOzeti = "George Orwell'in, toplumsal eleştirilerle dolu hiciv eseri.",
                    BaskiSayisi = 8500,
                    YazarID = 2,
                    KategoriID = 3,
                    YayineviID = 2,
                    KullaniciID = 2
                }
            );
        }
    }
}
