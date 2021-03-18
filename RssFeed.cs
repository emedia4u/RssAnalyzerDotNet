using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssAnalyzerDotNet
{
    public class RssFeed
    {
        public SyndicationFeed ParseRssDotNet(string rssLink)
        {

            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(rssLink))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            
            return feed;
        }
    }
}
