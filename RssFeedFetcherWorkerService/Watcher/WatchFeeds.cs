using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedFetcherWorkerService.Watcher
{
    internal class WatchFeeds
    {
        public void RunWatch(string[] urls)
        {
            foreach (var url in urls)
            {
                Console.WriteLine(url);
            }
        }
    }
}
