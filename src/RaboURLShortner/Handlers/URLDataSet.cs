using System;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using RaboURLShortner.Models;

namespace RaboURLShortner.Handlers
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

        public string GetIdByOriginalURL(URL urldata)
        {
            return (from element in urlDataSet.Descendants("url")
                    where element.Attribute("original").Value == urldata.Original
                    select element.Attribute("id").Value).FirstOrDefault();
        }

        public bool OriginalUrlExists(string originalUrl)
        {
            return (from element in urlDataSet.Descendants("url")
                    where element.Attribute("original").Value == originalUrl
                    select element.Attribute("original").Value).Count() > 0;
        }


        public void PersistUrl(URL urldata)
        {
            var doc = urlDataSet;
            var root = new XElement("url");
            root.Add(new XAttribute("original", urldata.Original));
            root.Add(new XAttribute("id", urldata.Id));
            root.Add(new XAttribute("created", urldata.Created));
            root.Add(new XAttribute("createdby", urldata.CreatedBy));
            doc.Element("root").Add(root);

            var nextIdValue = GetNextId() + 1;
            doc.Root.SetAttributeValue("nextIdValue", nextIdValue);

            doc.Save(xmlFile);
        }
    }
}