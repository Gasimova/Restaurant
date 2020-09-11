using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        
        public string Password { get; set; }

        [NotMapped]
        public string RepeatPassword { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
     
        public DateTime CreatedDate { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Message> Messages { get; set; }
        public List<Order> Orders { get; set; }

    }
}