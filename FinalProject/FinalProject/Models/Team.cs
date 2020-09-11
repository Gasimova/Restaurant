using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Surname { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}