using System.Collections.Generic;

namespace WepApiProjeCore.Models
{
    public interface ITaksitlerRepository
    {
        IEnumerable<Taksitler> GetAllTaksitler();
        Taksitler GetTaksitlerById(int id);
        Taksitler AddTaksitler(Taksitler taksitler);
        Taksitler UpdateTaksitler(Taksitler taksitler);
        void DeleteTaksitler(int? id);
    }
}
