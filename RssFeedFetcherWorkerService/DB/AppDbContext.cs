using Microsoft.EntityFrameworkCore;
using RssFeedFetcherWorkerService.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedFetcherWorkerService.DB
{
    internal class AppDbContext : DbContext
    {
        public DbSet<FeedEntity> Feeds { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
