using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmMenuDetails
    {
        public Menu Menu { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Tag> Tags { get; set; }
        public List<InstaFeed> InstaFeeds { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
    }
}