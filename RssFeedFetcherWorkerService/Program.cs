using Microsoft.EntityFrameworkCore;
using RssFeedFetcherWorkerService.DB;
using RssFeedFetcherWorkerService.Watcher;

namespace RssFeedFetcherWorkerService
{
    internal class Program
    {

        private static string[] urls =
        {
                 "https://stackoverflow.blog/feed/",
                 "https://dev.to/feed",
                 "https://www.freecodecamp.org/news/rss",
                 "https://martinfowler.com/feed.atom",
                 "https://codeblog.jonskeet.uk/feed/",
                 "https://devblogs.microsoft.com/visualstudio/feed/",
                 "https://feed.infoq.com/",
                 "https://css-tricks.com/feed/",
                 "https://codeopinion.com/feed/",
                 "https://andrewlock.net/rss.xml",
                 "https://michaelscodingspot.com/index.xml",
                 "https://www.tabsoverspaces.com/feed.xml"
         };

        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost; Database=RssFeedsDB; TrustServerCertificate=True; Trusted_Connection=True");

            var db = new AppDbContext(optionsBuilder.Options);

            db.Database.EnsureCreated();

            while (true)
            {
                var watch = new WatchFeeds();
                watch.RunWatch(urls);

                Thread.Sleep(1000 * 60);
            }
        }
    }
}