using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmAdminIndex
    {
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }
        public List<Subscribe> Subscribes { get; set; }
        public Order Order { get; set; }
        public List<InstaFeed> InstaFeeds { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Message> Messages { get; set; }
    }
}