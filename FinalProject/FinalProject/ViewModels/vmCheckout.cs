using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmCheckout
    {
        public List<Tag> Tags { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Order> Orders { get; set; }
        public List<InstaFeed> InstaFeeds { get; set; }
    }
}