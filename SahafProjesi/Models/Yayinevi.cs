namespace SahafProjesi.Models
{
    public class Yayinevi
    {
        public int YayineviID { get; set; }
        public string? YayineviAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
