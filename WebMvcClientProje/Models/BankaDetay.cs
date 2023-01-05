using System.ComponentModel.DataAnnotations;

namespace WebMvcClientProje.Models
{
    public class BankaDetay
    {
        public int BankaDetayID { get; set; }
        public int BankaID { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Sifre { get; set; }
        public string MagazaNo { get; set; }
        public string Host { get; set; }
    }
}
