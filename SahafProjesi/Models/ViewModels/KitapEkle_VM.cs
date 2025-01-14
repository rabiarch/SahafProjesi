namespace SahafProjesi.Models.ViewModels
{
    public class KitapEkle_VM
    {
        public string? KitapAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public DateTime BasimYili { get; set; }
        public int BaskiSayisi { get; set; }
        public string? KitapOzeti { get; set; }
        public IFormFile KapakResmi { get; set; } 

        public int? YazarID { get; set; }
        public int? KategoriID { get; set; }
        public int? YayineviID { get; set; }
        public int? KullaniciID { get; set; }
    }
}
