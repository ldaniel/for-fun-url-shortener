using System;
using System.Collections.Generic;
using URLShortener.Models;

namespace URLShortener.Handlers
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

        public URL GetIdByOriginalURL(string original)
        {
            return urlDataSet.GetIdByOriginalURL(original);
        }

        public IEnumerable<URL> GetURLsByUser(string user)
        {
            return urlDataSet.GetURLsByUser(user);
        }

        private bool IsAlreadyShortened(URL urldata)
        {
            return urlDataSet.OriginalUrlExists(urldata);
        }

        private bool IsAliasExistsForThisOriginalURL(URL urldata)
        {            
            return urlDataSet.AliasExists(urldata);
        }

        public URL InsertNewURL(URL urldata)
        {
            if (IsAliasExistsForThisOriginalURL(urldata))
            {
                urldata.Status = Status.AliasExists;
            }
            else
            {
                if (IsAlreadyShortened(urldata))
                {
                    urldata.Status = Status.URLExists;
                    urldata.Id = GetIdByOriginalURL(urldata.Original).Id;
                }
                else
                {
                    urldata.Status = Status.NewURL;

                    if (urldata.Id == String.Empty)
                        urldata.Id = AlphabetTest.Encode(urlDataSet.GetNextId());
                        
                    urlDataSet.PersistUrl(urldata);
                }
            }

            return urldata;
        }

        public void AddHit(string alias)
        {
            urlDataSet.AddHit(alias);
        }
    }
}