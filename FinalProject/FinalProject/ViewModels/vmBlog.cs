using FinalProject.Migrations;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class vmBlog
    {
        public Blog Blog { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public List<Message> Messages { get; set; }
        public Message Message { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Tag> Tags { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public List<User> Users { get; set; }
        public List<InstaFeed> InstaFeeds { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }


    }
}