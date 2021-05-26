using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LakewoodScoopScraper.Scraping
{
    public static class Scraper
    {
        public static List<LSPost> ScrapeLS()
        {
            var results = new List<LSPost>();
            var html = GetLSHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> postResults = document.QuerySelectorAll(".post");

            foreach (IElement result in postResults)
            {
                var LSResult = new LSPost();

                var title = result.QuerySelector("h2");
                if (title == null)
                {
                    continue;
                }

                LSResult.Title = title.TextContent;

                var commentsCount = result.QuerySelector("div.backtotop");
                if (commentsCount != null)
                {
                    LSResult.CommentsCount = commentsCount.TextContent;

                }

                var anchorTag = result.QuerySelector("a.more-link");
                if (anchorTag != null)
                {
                    LSResult.LinkUrl = anchorTag.Attributes["href"].Value;
                }

                var text = result.QuerySelector("p");
                if (text != null)
                {
                    LSResult.Text = text.TextContent;
                }

                var imageElement = result.QuerySelector("img");
                if (imageElement != null)
                {
                    LSResult.ImageUrl = imageElement.Attributes["src"].Value;
                }

                results.Add(LSResult);
            }

            return results;
        }

        private static string GetLSHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = $"https://www.thelakewoodscoop.com/";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
