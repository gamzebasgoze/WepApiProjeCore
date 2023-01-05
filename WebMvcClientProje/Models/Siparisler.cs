using System.ComponentModel.DataAnnotations;

namespace WebMvcClientProje.Models
{
    public class Siparisler
    {
        public int SiparislerID { get; set; }
        public int UyeID { get; set; }
        [Required(ErrorMessage = "Lütfen sipariş tipini giriniz")]
        public string SiparisTipi { get; set; }
        public string SiparisTarih { get; set; }
        [Required(ErrorMessage = "Lütfen adet giriniz")]
        public int Adet { get; set; }
        [Required(ErrorMessage = "Lütfen tutar giriniz")]
        public int Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
