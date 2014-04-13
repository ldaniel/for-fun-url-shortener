using System;
using URLShortener.UI.Web.Models;

namespace URLShortener.UI.Web.Handlers
{
    public class XMLHandler
    {
        private IURLDataSet urlDataSet;

        public XMLHandler(IURLDataSet urlDataSet)
        {
            this.urlDataSet = urlDataSet;
        }

        public XMLHandler()
        {
            urlDataSet = new URLDataSet();
        }

        public URL GetURLByID(string id)
        {
            return urlDataSet.GetUrlByID(id);
        }

        private bool IsAlreadyShortened(URL urldata)
        {
            return urlDataSet.OriginalUrlExists(urldata.Original);
        }

        public string InsertNewURL(URL urldata)
        {
            if (IsAlreadyShortened(urldata) == false)
            {
                if (urldata.Id == String.Empty)
                    urldata.Id = AlphabetTest.Encode(urlDataSet.GetNextId());

                urlDataSet.PersistUrl(urldata);
            }

            return urlDataSet.GetIdByOriginalURL(urldata);
        }
    }
}
