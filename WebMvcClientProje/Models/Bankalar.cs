using System.ComponentModel.DataAnnotations;

namespace WebMvcClientProje.Models
{
    public class Bankalar
    {
        public int BankaID { get; set; }
        [Required(ErrorMessage = "Lütfen banka adını giriniz")]
        public string BankaAdi { get; set; }
        public string BankaLogo { get; set; }
        public string Aktif { get; set; }
    }
}
