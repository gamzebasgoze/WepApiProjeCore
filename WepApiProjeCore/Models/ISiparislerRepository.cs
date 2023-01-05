using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface ISiparislerRepository
    {
        IEnumerable<Siparisler> GetAllSiparisler();
        Siparisler GetSiparislerById(int id);
        Siparisler AddSiparisler(Siparisler siparisler);
        Siparisler UpdateSiparisler(Siparisler siparisler);
        void DeleteSiparisler(int? id);
    }
}
