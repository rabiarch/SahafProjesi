using System.ComponentModel.DataAnnotations;

namespace SahafProjesi.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string? Ad { get; set; }

        //[Display(Name = "Kullanıcı Adı")]  //CleanCode olamdığı için bunu yapmıyoruz...
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
        public int? Yas { get; set; }
        //Kullanıcının kitap girebilmesi için kiataplar listesi tanımladık.
        public ICollection<Kitap>? Kitaplar { get; set; }

    }
}
