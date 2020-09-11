using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
       
        public string Dimentions { get; set; }

        [ForeignKey("MenuCategory")]
        public int MenuCategoryId { get; set; }
        
        public MenuCategory MenuCategory { get; set; }

    }
}