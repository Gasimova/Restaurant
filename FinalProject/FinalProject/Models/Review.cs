using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Reviews { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}