using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Accordion
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}