using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace RssAnalyzerDotNet
{
    public class UpToDate
    {
        public bool IsUpToDate(SyndicationFeed rssFeed, int daysOld)
        {
            List<string> listUpdates = new List<string>();
            
            if (rssFeed != null)
            {
                foreach (var element in rssFeed.Items)
                {
                    //Console.WriteLine($"Date: {element.PublishDate.DateTime}");
                    //Console.WriteLine($"Title: {element.Title.Text}");
                    listUpdates.Add(element.PublishDate.DateTime.ToString());
                }
            }

            var maxDate = listUpdates.Max();
            
            if (Convert.ToDateTime(maxDate) <= DateTime.Now.AddDays(-daysOld))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
