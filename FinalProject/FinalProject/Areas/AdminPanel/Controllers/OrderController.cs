using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class OrderController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Order
        public ActionResult Index()
        {
            List<Order> orders = context.Orders.Include("Menu").Include("User").ToList();
            return View(orders);
        }

       
    }
}