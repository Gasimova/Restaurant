using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}