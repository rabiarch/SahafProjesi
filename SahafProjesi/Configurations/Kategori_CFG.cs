using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahafProjesi.Models;

namespace SahafProjesi.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            //throw new NotImplementedException();

            builder.Property(x=> x.KategoriAdi).HasMaxLength(50);

            builder.HasData(
                new Kategori() { KategoriID = 1, KategoriAdi = "Roman" },
                new Kategori() { KategoriID = 2, KategoriAdi = "Makale" },
                new Kategori() { KategoriID = 3, KategoriAdi = "Hikaye" },
                new Kategori() { KategoriID = 4, KategoriAdi = "Felsefe" }
            );
        }
    }
}
