using Microsoft.VisualStudio.TestTools.UnitTesting;
using RssAnalyzerDotNet;

namespace UnitTestRssAnalyzer
{
    [TestClass]
    public class TestIsUpToDate
    {
        [TestMethod]
        public void IsUpToDateShouldReturnBool()
        {
            var rssFeed = new RssFeed();
            var upToDate = new UpToDate();
            var daysOld = 2;
            var rssLink = "https://www.politico.com/rss/politicopicks.xml";

            var feed = rssFeed.ParseRssDotNet(rssLink);
            var result = upToDate.IsUpToDate(feed, daysOld);

            Assert.IsTrue(result);
        }
    }
}
