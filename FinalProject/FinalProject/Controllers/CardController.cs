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
    public class CardController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Card
        public ActionResult Index()
        {
            ViewBag.setting = context.Settings.FirstOrDefault();

            vmCard card = new vmCard();
            card.Tags = context.Tags.ToList();
            card.Blogs = context.Blogs.ToList();
            card.InstaFeeds = context.InstaFeeds.ToList();

            if (Request.Cookies["Card"]!=null)
            {
                List<string> Card = Request.Cookies["Card"].Value.Split(',').ToList();
                Card.RemoveAt(Card.Count - 1);
                ViewBag.CardCount = Card.Count;
                card.Menu = context.Menus.Where(c => Card.Contains(c.Id.ToString()) == true).ToList();
            }
            
            return View(card);
        }



    }
}