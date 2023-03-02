using Microsoft.EntityFrameworkCore;
using RssFeedFetcherWorkerService.DB;
using RssFeedFetcherWorkerService.DB.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task <List<FeedEntity>>ParseXML(string[] urls)
        {
            List<FeedEntity> newFeedsList = new List<FeedEntity>();
            foreach (var url in urls)
            {
                if (urls == null || urls.Length == 0)
                {
                    throw new ArgumentException("At least one URL must be provided.", nameof(urls));
                }

                var feed = await LoadFeedAsync(url);
                if (feed != null)
                {
                    foreach (var item in feed.Items)
                    {
                        var feedTitle = item.Title.Text;
                        var feedLink = item.Links.FirstOrDefault()?.Uri.ToString();

                        var newFeed = new FeedEntity();

                        newFeed.Link = item.Links.FirstOrDefault()?.Uri.ToString();
                        newFeed.Title = item.Title.Text;
                        var summary = item.Summary.Text;
                        newFeed.Description = Regex.Replace(summary, "<[^>]*>", "").Trim().Replace("\n", " ");
                        var authorNames = string.Join(", ", item.Authors.Select(a => a.Name));
                        newFeed.Author = string.IsNullOrEmpty(authorNames) ? "unknown" : authorNames;
                        newFeed.Image = item.Links.FirstOrDefault()?.Uri.ToString();
                        var categories = string.Join(",", item.Categories.Select(c => c.Name));
                        newFeed.Tags = categories;
                        newFeed.PublishedAt = item.PublishDate.UtcDateTime;

                        newFeedsList.Add(newFeed);   
                    }
                }
            }
            return newFeedsList;
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

        public async Task MakeUniqueListAndSaveToAsync(string[] urls)
        {
            var feedsFromDb = await _db.Feeds.ToListAsync();
            //get unique list for saving to db
            var newFeedsList = await ParseXML(urls);
            var outputList = newFeedsList.Union(feedsFromDb).ToList();
            var uniqList = outputList.DistinctBy(i => i.Title).ToList();

            await _db.Feeds.AddRangeAsync(uniqList);
            Console.WriteLine($"We added {uniqList.Count} feeds from our DB");  
            await _db.SaveChangesAsync();
        }
    }
}
