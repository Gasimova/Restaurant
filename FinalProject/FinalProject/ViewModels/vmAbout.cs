using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmAbout
    {
        public WeAreVincent WeAreVincents { get; set; }
        public List<Galery> Galeries { get; set; }
        public List<Menu> Menus { get; set; }
        public List<User> Users { get; set; }
        public Setting Setting { get; set; }
    }
}