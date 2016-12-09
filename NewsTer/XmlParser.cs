using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace NewsTer
{
    class XmlParser
    {
        private string url;
        private XmlDocument doc;
        private ObservableCollection<Article> list;

        public XmlParser(string url)
        {
            this.url = url;
            this.doc = new XmlDocument();
            this.list = new ObservableCollection<Article>();
        }

        public ObservableCollection<Article> FetchArticles()
        {
            doc.Load(url);

            XmlElement rootNode = doc.DocumentElement;
            XmlNodeList nodes = rootNode.SelectNodes("channel/item");

            foreach (XmlNode node in nodes)
            {
                String GUID = node["guid"].InnerText;
                String title = node["title"].InnerText;
                DateTime date = Convert.ToDateTime(node["pubDate"].InnerText);
                String description = node["description"].InnerText;
                String category;
                try
                {
                    category = (node["category"].InnerText == null) ? node["category"].InnerText : " ";
                }
                catch (NullReferenceException)
                {
                    category = "null";
                }

                String hashTag;
                try
                {
                    hashTag = node["category"].InnerText;
                }
                catch (NullReferenceException)
                {
                    hashTag = "#null";
                }
                Article article = new Article(GUID, title, date, description, category, hashTag);
                list.Add(article);
            }
            return list;
        }
    }
}
