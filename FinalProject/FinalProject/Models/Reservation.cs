using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Phone { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(2000)]
        public string Requests { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}