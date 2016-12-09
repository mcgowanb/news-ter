using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsTer
{
    static class Utility
    {
        public enum WebSites { TheJournal, The42, TheDailyEdge };

        public static String GetWebURI(WebSites site)
        {
            String URI = null;
            switch (site)
            {
                case WebSites.TheJournal:
                URI = Properties.Settings.Default.TheJournalXmlUri;
                    break;
                case WebSites.TheDailyEdge:
                    URI = Properties.Settings.Default.DailyEdgeXmlUri;
                    break;
                case WebSites.The42:
                    URI = Properties.Settings.Default.The42XmlUri;
                    break;

            }
            return URI;
        }
    }
}
