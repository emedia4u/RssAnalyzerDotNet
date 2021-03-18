using System;
using System.Linq;

namespace RssAnalyzerDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var rssFeed = new RssFeed();
            // Pass companyName in args
            var companyName = "Politico";
            var today = DateTime.Today;
            // Pass daysOld in args
            var daysOld = 2;

            Console.WriteLine("CompanyName: " + companyName);
            Console.WriteLine();
            // Pass rssLink in args
            string rssLink = "https://www.politico.com/rss/politicopicks.xml";

            var result = rssFeed.ParseRssDotNet(rssLink);
            DateTime[] updates = new DateTime[] { };
            
            if (result != null)
            {
                foreach (var element in result.Items)
                {
                    Console.WriteLine($"Date: {element.PublishDate.DateTime}");
                    Console.WriteLine($"Title: {element.Title.Text}");
                    
                    //updates.Append(element.PublishDate.DateTime.ToString());
                }
            }

            //if (updates.Max() < DateTime.Now.AddDays(-daysOld))
            //{
            //    Console.WriteLine($"Out of date");
            //}

            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
