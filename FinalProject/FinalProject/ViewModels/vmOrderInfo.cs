using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmOrderInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }
       
        [Required]
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        public int[] ProductId { get; set; }
        public int[] ProductQuantity { get; set; }

    }
}