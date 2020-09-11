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
    public class TagController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Tag
        public ActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        public ActionResult Edit(int Id)
        {
            Tag tag = context.Tags.Find(Id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        public ActionResult Delete(int Id)
        {
            Tag tag = context.Tags.Find(Id);
            if (tag == null)
            {
                return HttpNotFound();
            }

            context.Tags.Remove(tag);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}