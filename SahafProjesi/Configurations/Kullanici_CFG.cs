using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahafProjesi.Models;
using SahafProjesi.Utilities;

namespace SahafProjesi.Configurations
{
    public class Kullanici_CFG : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            //throw new NotImplementedException(); //bunu silmezsek hata verir.

            builder.Property(x => x.Sifre)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.KullaniciAdi)
                .HasMaxLength(30);

            builder.HasData(
                new Kullanici { KullaniciID = 1, KullaniciAdi = "Rabia", Ad = "Rabia", Yas = 26, Sifre = Hasher.Md5Hasher("rabia123") },
                new Kullanici { KullaniciID = 2, KullaniciAdi = "Ayse", Ad = "Ayşe", Yas = 30, Sifre = Hasher.Md5Hasher("ayse123") }
                );
        }
    }
}
