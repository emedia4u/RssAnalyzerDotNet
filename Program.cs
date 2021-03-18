using System;
using System.Timers;

namespace RssAnalyzerDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const double intervalEveryDay = 24 * 60 * 60 * 1000; // Day interval
            // const double intervalEveryDay = 60 * 1000; // Minute interval
            Timer checkTime = new Timer(intervalEveryDay);
            checkTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            checkTime.Enabled = true;

            checkForTime_Elapsed(null,  null);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        static void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
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

                    //updates.Append(element.PublishDate.DateTime);
                }
            }

            //if (updates.Max() < DateTime.Now.AddDays(-daysOld))
            //{
            //    Console.WriteLine($"Out of date");
            //}
        }
    }
}
