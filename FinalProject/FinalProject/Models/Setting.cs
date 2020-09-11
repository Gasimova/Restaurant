using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        [NotMapped]
        public HttpPostedFileBase HeaderLogoFile { get; set; }

        public string FooterLogo { get; set; }
        [NotMapped]
        public HttpPostedFileBase FooterLogoFile { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }

        public string MasterCard { get; set; }
        [NotMapped]
        public HttpPostedFileBase MasterCardFile { get; set; }

        public string Visa { get; set; }
        [NotMapped]
        public HttpPostedFileBase VisaFile { get; set; }

        public string Weekday { get; set; }
        public string Weekend { get; set; }
        public int Phone { get; set; }
        public DateTime EstablishDate { get; set; }
    }
}