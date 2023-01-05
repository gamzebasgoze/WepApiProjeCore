using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface IOdemeTipRepository
    {
        IEnumerable<OdemeTip> GetAllOdemeTip();
        OdemeTip GetOdemeTipById(int id);
        OdemeTip AddOdemeTip(OdemeTip odemetip);
        OdemeTip UpdateOdemeTip(OdemeTip odemetip);
        void DeleteOdemeTip(int? id);
    }
}
