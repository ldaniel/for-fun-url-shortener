using RaboURLShortner.Models;

namespace RaboURLShortner.Handlers
{
    public interface IURLDataSet
    {
        int GetNextId();
        URL GetUrlByID(string id);
        string GetIdByOriginalURL(URL urldata);
        bool OriginalUrlExists(string originalUrl);
        void PersistUrl(URL urldata);
    }
}