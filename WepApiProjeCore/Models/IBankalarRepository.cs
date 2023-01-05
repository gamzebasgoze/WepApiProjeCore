using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface IBankalarRepository
    {
        IEnumerable<Bankalar> GetAllBankalar();
        Bankalar GetBankalarById(int id);
        Bankalar AddBankalar(Bankalar bankalar);
        Bankalar UpdateBankalar(Bankalar bankalar);
        void DeleteBankalar(int? id);
    }
}
