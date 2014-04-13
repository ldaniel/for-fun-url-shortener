using URLShortener.UI.Web.Models;

namespace URLShortener.UI.Web.Handlers
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