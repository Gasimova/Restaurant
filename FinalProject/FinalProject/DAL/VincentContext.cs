using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class VincentContext:DbContext
    {
        public VincentContext(): base("connectVincent")
        {

        }

        public DbSet<Accordion> Accordions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Galery> Galeries { get; set; }
        public DbSet<InstaFeed> InstaFeeds { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeAreVincent> WeAreVincents { get; set; }
    }
}