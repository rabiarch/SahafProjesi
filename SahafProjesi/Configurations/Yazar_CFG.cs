using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahafProjesi.Models;

namespace SahafProjesi.Configurations
{
    public class Yazar_CFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(x => x.YazarAdi).HasMaxLength(50);

            builder.HasData(
                new Yazar() { YazarID=1, YazarAdi="Paulo", YazarSoyadi="Coelho"},
                new Yazar() { YazarID=2, YazarAdi="Irvın", YazarSoyadi="Yalom"},
                new Yazar() { YazarID=3, YazarAdi="Jose", YazarSoyadi="Saramago"},
                new Yazar() { YazarID=4, YazarAdi="Stefan", YazarSoyadi="Zweig"}
                );
        }
    }
}
