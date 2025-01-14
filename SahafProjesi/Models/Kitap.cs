namespace SahafProjesi.Models
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public string? KitapAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public DateTime BasimYili { get; set; }
        public int BaskiSayisi { get; set; }
        public string? KitapOzeti { get; set; }
        public string? KapakResmi { get; set; }
        //public IFormFile KapakResmi { get; set; }

        //nav

        public Yazar? Yazar { get; set; }   //? önemlidir. Olmazsa listelemelerde hata alıyoruz.
        public Kategori? Kategori { get; set; }
        public Yayinevi? Yayinevi { get; set; }
        public Kullanici? Kullanici { get; set; }


        //ForeignKey
        public int? YazarID { get; set; }
        public int? KategoriID { get; set; }
        public int? YayineviID { get; set; }
        public int? KullaniciID { get; set; }
    }

}
