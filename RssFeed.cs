using System;
using System.ServiceModel.Syndication;
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
