using System.ComponentModel.DataAnnotations;

namespace WebMvcClientProje.Models
{
    public class Taksitler
    {
        public int TaksitID { get; set; }
        public int BankaID { get; set; }
        [Required(ErrorMessage = "Lütfen taksit sayısını giriniz")]
        public int Taksit { get; set; }
        [Required(ErrorMessage = "Lütfen ek taksit sayısını giriniz")]
        public int EkTaksit { get; set; }
        public int VadeFarki { get; set; }
        public string Aciklama { get; set; }
    }
}
