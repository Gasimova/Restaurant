using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Subtitle { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}