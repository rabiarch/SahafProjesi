using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SahafProjesi.Models;

namespace SahafProjesi.Configurations
{
    public class Yayinevi_CFG : IEntityTypeConfiguration<Yayinevi>
    {
        public void Configure(EntityTypeBuilder<Yayinevi> builder)
        {
            builder.HasData(
                new Yayinevi { YayineviID = 1, YayineviAdi = "Can" },
                new Yayinevi { YayineviID = 2, YayineviAdi = "İş Bankası" },
                new Yayinevi { YayineviID = 3, YayineviAdi = "Yapı Kredi Yayınları" },
                new Yayinevi { YayineviID = 4, YayineviAdi = "İthaki" }
            );
        }
    }
}
