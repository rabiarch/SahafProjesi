using Microsoft.AspNetCore.Mvc.Rendering;

namespace SahafProjesi.Models.ViewModels
{
    public class KitapEklemeEkrani_VM
    {
        public KitapEkle_VM Kitap { get; set; }
        public SelectList Kategoriler { get; set; }  //SelectList demek seçenekleri gösterir pencere demektir.
        public SelectList Yayinevleri { get; set; }
        public SelectList Yazarlar { get; set; }

    }
}
