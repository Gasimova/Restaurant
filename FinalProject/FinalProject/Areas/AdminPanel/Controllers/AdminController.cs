using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class AdminController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Admin
        public ActionResult Index()
        {
            List<Admin> admins = context.Admins.ToList();
            return View(admins);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(admin);
                }
               
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);
                    admin.ImageFile.SaveAs(imgPath);
                    admin.Image = imgName;
                    //admin.Password = Crypto.HashPassword(admin.Password);

                context.Admins.Add(admin);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(admin);
        }

        public ActionResult Edit(int Id)
        {
            Admin admin = context.Admins.Find(Id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin admin1 = context.Admins.Find(admin.Id);
                if (admin.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), admin1.Image);
                    System.IO.File.Delete(oldPath);

                    admin.ImageFile.SaveAs(imgPath);
                    admin1.Image = imgName;

                }

                admin1.Email = admin.Email;
                admin1.Name = admin.Name;
                admin1.Surname = admin.Surname;
                admin1.Username = admin.Username;
                admin1.Password = Crypto.HashPassword(admin.Password);

                context.Entry(admin1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public ActionResult Delete(int Id)
        {
            Admin admin = context.Admins.Find(Id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            context.Admins.Remove(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}