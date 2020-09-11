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
    public class AboutController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: About
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

            vmAbout about = new vmAbout();
            about.WeAreVincents = context.WeAreVincents.FirstOrDefault();
            about.Galeries = context.Galeries.ToList();
            about.Menus = context.Menus.ToList();
            about.Users = context.Users.ToList();
            about.Setting = context.Settings.FirstOrDefault();
            return View(about);
        }

        public ActionResult Reservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reservation(Reservation reserv)
        {
            if (ModelState.IsValid)
            {
                reserv.CreatedDate = DateTime.Now;
                context.Reservations.Add(reserv);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserv);
        }
    }
}