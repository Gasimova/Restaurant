using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}