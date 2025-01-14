namespace SahafProjesi.Models.ViewModels
{
    public class Login_VM  //VM'leri ekrana classtaki bazı property'leri getirmek istediğimiz zaman kullanırız. Burada ekrana sadece kullanıcı adı ve şifre propertylerini getiriyoruz.
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
