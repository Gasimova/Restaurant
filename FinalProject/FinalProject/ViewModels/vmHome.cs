using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmHome
    {
        public List<Slider> Sliders { get; set; }
        public List<Menu> Menus { get; set; }
        public WeAreVincent WeAreVincents { get; set; }
        public List<Blog> Blogs { get; set; }
        public Setting Setting { get; set; }
        public List<Review> Reviews { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
    }
}