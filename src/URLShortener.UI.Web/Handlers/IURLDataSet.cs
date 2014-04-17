using System.Collections.Generic;
using URLShortener.Models;

namespace URLShortener.Handlers
{
    public interface IURLDataSet
    {
        int GetNextId();
        URL GetUrlByID(string id);
        URL GetIdByOriginalURL(string original);
        bool OriginalUrlExists(URL urldata);
        bool AliasExists(URL urldata);
        void PersistUrl(URL urldata);
        IEnumerable<URL> GetURLsByUser(string user);
        void AddHit(string alias);
    }
}