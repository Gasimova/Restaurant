using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmTeam
    {
        public List<Team> Teams { get; set; }
        public List<Accordion> Accordions { get; set; }
        public Blog Blog { get; set; }
    }
}