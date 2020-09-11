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
    public class MenuController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Menu
        public ActionResult Index()
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

            
            ViewBag.MenuCategory = context.MenuCategories.ToList();
            List<Menu> menus = context.Menus.Include("MenuCategory").ToList();
            
            return View(menus);
        }

        public ActionResult Details(int Id)
        {
            ViewBag.setting = context.Settings.FirstOrDefault();


            vmMenuDetails details = new vmMenuDetails();
            details.Menu = context.Menus.Find(Id);
            details.Tags = context.Tags.ToList();
            details.InstaFeeds = context.InstaFeeds.ToList();
            details.MenuCategories = context.MenuCategories.ToList();
            details.Menus = context.Menus.Include("MenuCategory").ToList();

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

           
            return View(details);
        }
    }
}