using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Home
        [Logout]
        public ActionResult Index()
        {
            vmAdminIndex admin = new vmAdminIndex();
            admin.Users = context.Users.Include("Messages").ToList();
            admin.Orders = context.Orders.Include("User").ToList();
            admin.Subscribes = context.Subscribes.ToList();
            admin.Order = context.Orders.FirstOrDefault();
            admin.InstaFeeds = context.InstaFeeds.ToList();
            admin.Reviews = context.Reviews.ToList();
            admin.Messages = context.Messages.Include("User").ToList();
            return View(admin);
        }


        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(vmLogin login)
        {
            if (ModelState.IsValid)
            {
                Admin admin = context.Admins.FirstOrDefault(a =>a.Email == login.Email);
                if (admin != null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password , login.Password) == true)
                    {
                        Session["Loginner"] = admin;
                        Session["LoginnerId"] = admin.Id;

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Incorrect Email");
                }
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [Logout]
        public ActionResult Subscribe()
        {
            List<Subscribe> subscribes = context.Subscribes.ToList();
            return View(subscribes);
        }

    }
}