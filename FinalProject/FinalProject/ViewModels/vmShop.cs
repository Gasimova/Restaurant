using FinalProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmShop
    {
        public List<Tag> Tags { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
        public List<Menu> Menus { get; set; }
        public Menu Menu { get; set; }
        public List<string> Card { get; set; }

        public int PageCount { get; set; }
        public int CurrentPage { get; set; }



    }
}