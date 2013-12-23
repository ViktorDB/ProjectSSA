using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using ProjectSSA.Models;
using ProjectSSA.Models.DAL;

namespace ProjectSSA.Controllers
{
    public class RSSController : ApiController
    {
        public Rss20FeedFormatter GetFeed()
        {
            List<Band> bands = BandRepository.GetBands();

            var feed = new SyndicationFeed("Festival", "Het nieuwsoverzicht van Festival", new Uri("http://localhost:8080/"));
            feed.Authors.Add(new SyndicationPerson("Sander Lacaeyse"));
            feed.Categories.Add(new SyndicationCategory("Music festival"));
            feed.Description = new TextSyndicationContent("Het nieuwsoverzicht van Festival");
            
            
            var c = DateTime.Now.ToString("yyyy-MM-dd");
            var x = Convert.ToDateTime(c);

            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (Band n in bands)
            {
                SyndicationItem item = new SyndicationItem(
                n.Name,
                n.Description,
                new Uri("http://localhost:35767/News/Article/" + n.ID),
                n.ID.ToString(),
                x);

                items.Add(item);
            }
            feed.Items = items;

            return new Rss20FeedFormatter(feed);
        }
    }
}