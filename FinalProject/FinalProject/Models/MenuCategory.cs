using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }

        
    }
}