using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class UserController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/User
        public ActionResult Index()
        {
            List<User> user = context.Users.ToList();
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int Id)
        {
            User user = context.Users.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}