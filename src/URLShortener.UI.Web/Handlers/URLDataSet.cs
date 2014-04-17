using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using URLShortener.Models;

namespace URLShortener.Handlers
{
    public class URLDataSet : IURLDataSet
    {
        private string xmlFile = ConfigurationManager.AppSettings["xml_path"].ToString();
        private XDocument urlDataSet;

        public URLDataSet()
        {
            urlDataSet = XDocument.Load(xmlFile);
        }

        private URL ConvertToUrl(XElement url)
        {
            return new URL
            {
                Original = url.Attribute("original").Value,
                Id = url.Attribute("id").Value,
                Created = Convert.ToDateTime(url.Attribute("created").Value),
                CreatedBy = url.Attribute("createdby").Value,
                Hits = Convert.ToInt32(url.Attribute("hits").Value),
            };
        }

        public int GetNextId()
        {
            return Convert.ToInt32(urlDataSet.Root.Attribute("nextIdValue").Value);
        }

        public URL GetUrlByID(string id)
        {
            var urls = from element in urlDataSet.Descendants("url")
                       where element.Attribute("id").Value == id
                       select ConvertToUrl(element);

            return urls.FirstOrDefault();
        }

        public URL GetIdByOriginalURL(string original)
        {
            var urls = from element in urlDataSet.Descendants("url")
                       where element.Attribute("original").Value == original
                       select ConvertToUrl(element);

            return urls.FirstOrDefault();
        }

        public bool OriginalUrlExists(URL urldata)
        {
            return (from element in urlDataSet.Descendants("url")
                    where element.Attribute("original").Value == urldata.Original
                    select element.Attribute("original").Value).Count() > 0;
        }

        public IEnumerable<URL> GetURLsByUser(string user)
        {
            return from element in urlDataSet.Descendants("url")
                   where element.Attribute("createdby").Value == user
                   select ConvertToUrl(element);
        }

        public bool AliasExists(URL urldata)
        {
            if (String.IsNullOrEmpty(urldata.Id))
                return false;

            return (from element in urlDataSet.Descendants("url")
                    where element.Attribute("id").Value == urldata.Id
                    select element.Attribute("id").Value).Count() > 0;
        }

        public void AddHit(string alias)
        {
            var doc = urlDataSet;

            XElement url = (from element in urlDataSet.Descendants("url")
                            where element.Attribute("id").Value == alias
                            select element).FirstOrDefault();

            url.Attribute("hits").Value = (Convert.ToInt32(url.Attribute("hits").Value) + 1).ToString();
            doc.Save(xmlFile);
        }

        public void PersistUrl(URL urldata)
        {
            var doc = urlDataSet;
            var root = new XElement("url");
            root.Add(new XAttribute("original", urldata.Original));
            root.Add(new XAttribute("id", urldata.Id));
            root.Add(new XAttribute("created", urldata.Created));
            root.Add(new XAttribute("createdby", urldata.CreatedBy));
            root.Add(new XAttribute("hits", urldata.Hits));
            doc.Element("root").Add(root);

            var nextIdValue = GetNextId() + 1;
            doc.Root.SetAttributeValue("nextIdValue", nextIdValue);

            doc.Save(xmlFile);
        }
    }
}