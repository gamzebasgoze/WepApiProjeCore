using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface IBankaDetayRepository
    {
        IEnumerable<BankaDetay> GetAllBankaDetay();
        BankaDetay GetBankaDetayById(int id);
        BankaDetay AddBankaDetay(BankaDetay bankadetay);
        BankaDetay UpdateBankaDetay(BankaDetay bankadetay);
        void DeleteBankaDetay(int? id);
    }
}
