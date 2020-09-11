using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class WeAreVincent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        [Column(TypeName ="ntext")]
        public string Text { get; set; }
        public string Image1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image1File { get; set; }
        public string Image2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image2File { get; set; }
    }
}