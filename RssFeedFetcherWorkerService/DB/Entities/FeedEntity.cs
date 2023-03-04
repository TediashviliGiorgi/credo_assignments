using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedFetcherWorkerService.DB.Entities
{
    internal class FeedEntity
    {
        public int Id { get; set; } 
        public string? Link { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Image { get; set; }
        public string? Tags { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
