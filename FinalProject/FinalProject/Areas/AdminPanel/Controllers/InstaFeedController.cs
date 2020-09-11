using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class InstaFeedController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/InstaFeed
        public ActionResult Index()
        {
            List<InstaFeed> instaFeeds = context.InstaFeeds.ToList();
            return View(instaFeeds);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InstaFeed insta)
        {
            if (ModelState.IsValid)
            {
                if (insta.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(insta);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + insta.ImageFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                insta.ImageFile.SaveAs(imgPath);
                insta.Image = imgName;

                context.InstaFeeds.Add(insta);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insta);
        }

        public ActionResult Edit(int Id)
        {
            InstaFeed insta = context.InstaFeeds.Find(Id);
            if (insta == null)
            {
                return HttpNotFound();
            }
            return View(insta);
        }


        [HttpPost]
        public ActionResult Edit(InstaFeed insta)
        {
            if (ModelState.IsValid)
            {
                InstaFeed feed = context.InstaFeeds.Find(insta.Id);
                if (insta.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + insta.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), feed.Image);
                    System.IO.File.Delete(oldPath);

                    insta.ImageFile.SaveAs(imgPath);
                    feed.Image = imgName;

                }

                feed.Link = insta.Link;

                context.Entry(feed).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insta);
        }

        public ActionResult Delete(int Id)
        {
            InstaFeed insta = context.InstaFeeds.Find(Id);
            if (insta == null)
            {
                return HttpNotFound();
            }

            context.InstaFeeds.Remove(insta);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}