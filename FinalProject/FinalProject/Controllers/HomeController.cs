using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        VincentContext context = new VincentContext();
        public ActionResult Index()
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

            vmHome home = new vmHome();
            home.Reviews = context.Reviews.ToList();
            home.Blogs = context.Blogs.ToList();
            home.Menus = context.Menus.ToList();
            home.WeAreVincents = context.WeAreVincents.FirstOrDefault();
            home.Setting = context.Settings.FirstOrDefault();
            home.Sliders = context.Sliders.ToList();
            home.MenuCategories = context.MenuCategories.ToList();
            return View(home);
        }


        public ActionResult Settings()
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

            int userId = (int)Session["LoginnerUserId"];
            vmBlog settings = new vmBlog();
            settings.Blogs = context.Blogs.ToList();
            settings.BlogCategories = context.BlogCategories.ToList();
            settings.InstaFeeds = context.InstaFeeds.ToList();
            settings.Tags = context.Tags.ToList();
            settings.Users = context.Users.ToList();
            settings.User = context.Users.Find(userId);
            return View(settings);
        }

        [HttpPost]
        public ActionResult Settings(User user)
        {
            ViewBag.setting = context.Settings.FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (user.Password !=null && user.Password != user.RepeatPassword)
                {
                    Session["PassError"] = true;
                    vmBlog settings1 = new vmBlog();
                    settings1.Blogs = context.Blogs.ToList();
                    settings1.BlogCategories = context.BlogCategories.ToList();
                    settings1.InstaFeeds = context.InstaFeeds.ToList();
                    settings1.Tags = context.Tags.ToList();
                    settings1.Users = context.Users.ToList();
                    settings1.User = user;
                    return View(settings1);
                }

                User user1 = (User)Session["LoginnerUser"];
                user1.Name = user.Name;
                user1.Surname = user.Surname;
                user1.Phone = user.Phone;
                user1.Email = user.Email;
                user1.Address = user.Address;
                if (user.Password!=null)
                {
                    user1.Password = Crypto.HashPassword(user.Password);
                }
                
                context.Entry(user1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            
            Session["ModelError"] = true;
            vmBlog settings = new vmBlog();
            settings.Blogs = context.Blogs.ToList();
            settings.BlogCategories = context.BlogCategories.ToList();
            settings.InstaFeeds = context.InstaFeeds.ToList();
            settings.Tags = context.Tags.ToList();
            settings.Users = context.Users.ToList();
            settings.User = user;
            return View(settings);
        }


        public JsonResult GetUserInfo()
        {
            int userId = (int)Session["LoginnerUserId"];
            var users = context.Users.OrderBy(o => o.Id).Where(u => u.Id == userId).Select(s => new {
                s.Id,
                s.Name,
                s.Username,
                s.Surname,
                s.Phone,
                s.Address,
                s.Email
            }).ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyOrders()
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
            int userId = (int)Session["LoginnerUserId"];
            vmBlog orders = new vmBlog();
            orders.Blogs = context.Blogs.ToList();
            orders.BlogCategories = context.BlogCategories.ToList();
            orders.InstaFeeds = context.InstaFeeds.ToList();
            orders.Tags = context.Tags.ToList();
            orders.Orders = context.Orders.Include("User").Include("Menu").Where(o=>o.UserId== userId).ToList();
            return View(orders);
        }

        public JsonResult GetUserOrders(int Id)
        {
            var orders = context.Orders.Include("Menu").Include("User").OrderBy(o => o.Id).Where(o => o.UserId == Id).Select(s=>new { 
                s.Id,
                s.Quantity,
                s.Price,
                s.UserId,
                s.MenuId
                         }).ToList();
            return Json(orders,JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignUp()
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
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
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

            if (ModelState.IsValid)
            {
                if (context.Users.Any(a=>a.Email==user.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already taken");
                    return View(user);
                }

                if (user.Password==null)
                {
                    ModelState.AddModelError("Password", "Password is required");
                    return View(user);
                }


                user.CreatedDate = DateTime.Now;
                user.Password = Crypto.HashPassword(user.Password);

                context.Users.Add(user);
                context.SaveChanges();

                Session["LoginnerUser"] = user;
                Session["LoginnerUserId"] = user.Id;
                
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Login()
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

           
            return View();
        }

        [HttpPost]
        public ActionResult Login(vmLogin login)
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


            if (ModelState.IsValid)
            {
                User user = context.Users.FirstOrDefault(u => u.Email == login.Email);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password) == true)
                    {
                        Session["LoginnerUser"] = user;
                        Session["LoginnerUserName"] = user.Name +" "+ user.Surname;
                        Session["LoginnerUserId"] = user.Id;

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect Username");
                }

               
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public JsonResult Subscribe(Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                subscribe.CreatedDate = DateTime.Now;

                context.Subscribes.Add(subscribe);
                context.SaveChanges();
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}