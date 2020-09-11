using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class BlogsController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Blogs
        public ActionResult Index(string tag, string word, int page = 1)
        {
            #region Card
            HttpCookie cookie = Request.Cookies["Card"];
            if (cookie != null)
            {
                List<string> Card = cookie.Value.Split(',').ToList();
                Card.RemoveAt(Card.Count - 1);

                ViewBag.Card = Card;
                ViewBag.CardCount = Card.Count;
            }
            else
            {
                ViewBag.CardCount = 0;
            }
            #endregion

            ViewBag.setting = context.Settings.FirstOrDefault();

            vmBlog blog = new vmBlog();
            List<Blog> blogs = context.Blogs.Include("Messages").Include("BlogCategory")
                                       .Where(b => ((tag != null ? b.Title.Contains(tag) : true) ||
                                                   (tag != null ? b.Text.Contains(tag) : true)) &&
                                                   ((!string.IsNullOrEmpty(word) ? b.Text.Contains(word) : true) ||
                                                   (!string.IsNullOrEmpty(word) ? b.Title.Contains(word) : true)))
                                       .ToList();

            blog.Blogs = blogs.OrderByDescending(o=>o.Id).Skip((page - 1) * 8).Take(8).ToList();

            blog.PageCount = Convert.ToInt32(Math.Ceiling(blogs.Count() / 8.0));
            blog.CurrentPage = page;
            return View(blog);
        }


        public ActionResult Detail(int Id)
        {
            ViewBag.setting = context.Settings.FirstOrDefault();

            #region Card
            HttpCookie cookie = Request.Cookies["Card"];
            if (cookie != null)
            {
                List<string> Card = cookie.Value.Split(',').ToList();
                Card.RemoveAt(Card.Count - 1);

                ViewBag.Card = Card;
                ViewBag.CardCount = Card.Count;
            }
            else
            {
                ViewBag.CardCount = 0;
            }
            #endregion

            vmBlog vmBlog = new vmBlog();
            vmBlog.Blog = context.Blogs.Include("Messages").FirstOrDefault(b => b.Id == Id);
            vmBlog.Blogs = context.Blogs.ToList();
            vmBlog.BlogCategories = context.BlogCategories.ToList();
            vmBlog.Messages = context.Messages.Include("User").ToList();
            vmBlog.Message = context.Messages.Include("User").FirstOrDefault();
            vmBlog.Tags = context.Tags.ToList();
            vmBlog.InstaFeeds = context.InstaFeeds.ToList();
            return View(vmBlog);
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.CreatedDate = DateTime.Now;
                message.UserId = (int)Session["LoginnerUserId"];

                context.Messages.Add(message);
                context.SaveChanges();
            }
            return RedirectToAction("Detail", new { Id = message.BlogId });
        }

        public JsonResult GetMessage(int Id)
        {
            var messages = context.Messages.Include("Blog").Include("User").Where(m=>m.BlogId==Id).Select(s=> new { 
                s.Id,
                s.Comment,
                s.BlogId,
                s.CreatedDate,
                s.UserId
                          }).ToList();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string word)
        {
                List<Blog> search = context.Blogs.Include("BlogCategory").Where(b => !string.IsNullOrEmpty(word) ? b.Text.Contains(word) : false ||
                                                                                     !string.IsNullOrEmpty(word) ? b.Title.Contains(word) : false).ToList();
                return View(search);
        }

        public ActionResult Tag(string tag)
        {
            List<Blog> blogs = context.Blogs.ToList();
            if (blogs != null)
            {
                blogs = context.Blogs.Where(t => !string.IsNullOrEmpty(tag) ? t.Title.Contains(tag) : false ||
                                                 !string.IsNullOrEmpty(tag) ? t.Text.Contains(tag) : false).ToList();
                return RedirectToAction("Index", "Blogs");
            }
            
            return View(blogs);
        }

        public ActionResult Pagenation(int page = 1)
        {
            return View();
        }

    }
}