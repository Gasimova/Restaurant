using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public int MenuId { get; set; }
        public User User { get; set; }
        public Menu Menu { get; set; }
    }
}