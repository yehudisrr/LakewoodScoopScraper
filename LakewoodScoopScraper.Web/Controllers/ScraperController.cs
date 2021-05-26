using LakewoodScoopScraper.Scraping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoopScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [Route("scrape")]
        public List<LSPost> Scrape()
        {
            return Scraper.ScrapeLS();
        }
    }
}
