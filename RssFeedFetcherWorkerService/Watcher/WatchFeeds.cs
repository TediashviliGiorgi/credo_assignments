using RssFeedFetcherWorkerService.DB;
using RssFeedFetcherWorkerService.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssFeedFetcherWorkerService.Watcher
{
    internal class WatchFeeds
    {
        private readonly AppDbContext _db;

        public WatchFeeds(AppDbContext db)
        {
            _db = db;
        }

        public async Task RunWatch(string[] urls)
        {
            foreach (var url in urls)
            {
               


                var feed = await LoadFeedAsync(url);
                foreach (var item in feed.Items)
                {
                    var feedTitle = item.Title.Text;
                    var feedLink = item.Links.FirstOrDefault()?.Uri.ToString();

                    var newFeed = new FeedEntity();

                    newFeed.Link = item.Links.FirstOrDefault()?.Uri.ToString();
                    newFeed.Title = item.Title.Text;
                    newFeed.Description = item.Summary.ToString();
                    newFeed.Author = item.Authors.FirstOrDefault()?.Name;
                    newFeed.Image = item.Links.FirstOrDefault(l => l.MediaType == "image/jpeg")?.Uri.ToString();
                    newFeed.Tags = item.Categories.ToString();
                    newFeed.PublishedAt = item.PublishDate.UtcDateTime;

                    _db.Feeds.Add(newFeed);
                    Console.WriteLine(newFeed.Title);
                    await _db.SaveChangesAsync();
                   
                }


            }
        }

        


        public async Task<SyndicationFeed> LoadFeedAsync(string url)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "MyUserAgent");

            var response = await httpClient.GetStringAsync(url);

            var stringReader = new StringReader(response);

            var reader = XmlReader.Create(stringReader);


            return SyndicationFeed.Load(reader);
        }

    }
}
