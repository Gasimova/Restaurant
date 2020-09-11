using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Address
    {
        public int Id { get; set; }
       [MaxLength(100)]
        public string Filial { get; set; }
        [MaxLength(500)]
        public string Street { get; set; }

        public int Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        public string Weekday { get; set; }
        public string Weekend { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string Map { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}