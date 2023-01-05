using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface IBankaHesaplariRepository
    {
        IEnumerable<BankaHesaplari> GetAllBankaHesaplari();
        BankaHesaplari GetBankaHesaplariById(int id);
        BankaHesaplari AddBankaHesaplari(BankaHesaplari bankahesaplari);
        BankaHesaplari UpdateBankaHesaplari(BankaHesaplari bankahesaplari);
        void DeleteBankaHesaplari(int? id);
    }
}
