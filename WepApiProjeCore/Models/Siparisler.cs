namespace WepApiProjeCore.Models
{
    public class Siparisler
    {
        public int SiparislerID { get; set; }
        public int UyeID { get; set; }
        public string SiparisTipi { get; set; }
        public string SiparisTarih { get; set; }
        public int Adet { get; set; }
        public int Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
