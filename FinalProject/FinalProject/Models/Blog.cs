using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string Author { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Column(TypeName ="ntext")]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogCategoryId { get; set; }

        public BlogCategory BlogCategory { get; set; }

        public List<Message> Messages { get; set; }

    }
}