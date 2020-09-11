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
    public class BlogController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Blog
        public ActionResult Index()
        {
            List<Blog> blogs = context.Blogs.ToList();
            return View(blogs);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = context.BlogCategories.ToList();
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog blog1 = new Blog();
                if (blog.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.Categories = context.BlogCategories.ToList();
                    return View(blog);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    blog.ImageFile.SaveAs(imagePath);
                    blog1.Image = imageName;
                }

                blog1.Text = blog.Text;
                blog1.Title = blog.Title;
                blog1.Date = DateTime.Now;
                blog1.Author = blog.Author;
                blog1.BlogCategoryId = blog.BlogCategoryId;
                blog1.CreatedDate = DateTime.Now;

                context.Blogs.Add(blog1);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Categories = context.BlogCategories.ToList();
            return View(blog);
        }


        public ActionResult Edit(int id)
        {
            Blog blog = context.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = context.BlogCategories.ToList();
            return View(blog);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog blog1 = context.Blogs.Find(blog.Id);

                if (blog.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blog1.Image);

                    blog.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(OldImagePath);

                    blog1.Image = imageName;
                }

                blog1.Author = blog.Author;
                blog1.BlogCategoryId = blog.BlogCategoryId;
                blog1.Text = blog.Text;
                blog1.Title = blog.Title;

                context.Entry(blog1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = context.BlogCategories.ToList();
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            Blog blog = context.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}