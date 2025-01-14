using Microsoft.EntityFrameworkCore;
using SahafProjesi.Models;
using System.Reflection;

namespace SahafProjesi.Data
{
    public class SahafDbContext : DbContext
    {
        public SahafDbContext()
        {
            
        }

        public SahafDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        //appsttingsjsonda connection string var. o yüzden configure etmiyoruz burada.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
