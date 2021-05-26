using System;

namespace LakewoodScoopScraper.Scraping
{
    public class LSPost
    {
        public string Title { get; set; }
        public string LinkUrl { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string CommentsCount { get; set; }
    }
}
