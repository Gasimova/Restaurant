using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class BlogCategoryController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/BlogCategory
        public ActionResult Index()
        {
            List<BlogCategory> blogCategories = context.BlogCategories.ToList();
            return View(blogCategories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogCategory category)
        {
            if (ModelState.IsValid)
            {
                context.BlogCategories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int Id)
        {
            BlogCategory category = context.BlogCategories.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(BlogCategory category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int Id)
        {
            BlogCategory category = context.BlogCategories.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            context.BlogCategories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}