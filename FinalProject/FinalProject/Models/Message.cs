using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        [MaxLength(2000)]
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
    }
}