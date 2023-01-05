namespace WepApiProjeCore.Models
{
    public class BankaHesaplari
    {
        public int BankaHesapID { get; set; }
        public int BankaID { get; set; }
        public string HesapSahibi { get; set; }
        public string HesapKurTip { get; set; }
        public string HesapNo { get; set; }
        public string IbanNo { get; set; }
    }
}
