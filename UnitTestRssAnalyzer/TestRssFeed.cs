using Microsoft.VisualStudio.TestTools.UnitTesting;
using RssAnalyzerDotNet;

namespace UnitTestRssAnalyzer
{
    [TestClass]
    public class TestRssFeed
    {
        [TestMethod]
        public void ParseRssDotNetShouldReturnFeedElements()
        {
            var rssFeed = new RssFeed();
            var rssLink = "https://www.politico.com/rss/politicopicks.xml";
            var result = rssFeed.ParseRssDotNet(rssLink);

            Assert.IsNotNull(result);
        }
    }
}
