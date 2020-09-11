using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmCard
    {
        public List<Menu> Menu { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<InstaFeed> InstaFeeds { get; set; }

        public string Response { get; set; }
    }
}