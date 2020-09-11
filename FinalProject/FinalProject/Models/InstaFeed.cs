using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class InstaFeed
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}