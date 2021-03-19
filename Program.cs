using System;
using System.Collections.Generic;
using System.Linq;
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

            if (args.Length == 0)
            {
                // Display message to user to provide parameters.
                Console.WriteLine("Please provide company name, RSS link and number of days inactive.");
            }
            else
            {
                // Loop through array to list args parameters.
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write(args[i] + Environment.NewLine);
                }
                // Keep the console window open after the program has run.
                Console.Read();
            }

            // Initial check
            checkForTime_Elapsed(null,  null);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        static void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            var rssFeed = new RssFeed();
            var upToDate = new UpToDate();
            // Pass companyName in args
            var companyName = "Politico";
            var today = DateTime.Today;
            // Pass daysOld in args
            var daysOld = 2;

            Console.WriteLine();
            // Pass rssLink in args
            string companyRssLink = "https://www.politico.com/rss/politicopicks.xml";
            //string companyRssLink = "http://rss.cnn.com/rss/cnn_topstories.rss";
            
            var feed = rssFeed.ParseRssDotNet(companyRssLink);

            var result = upToDate.IsUpToDate(feed, daysOld);

            if (!result)
            {
                Console.WriteLine(companyName + $" RSS Feed is " + daysOld + " days old ");
            }
            else
            {
                Console.WriteLine(companyName + $" RSS Feed is up to date");
            }
            
        }
    }
}
