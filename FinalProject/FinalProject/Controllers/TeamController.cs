using FinalProject.DAL;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class TeamController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Team
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

            vmTeam team = new vmTeam();
            team.Accordions = context.Accordions.ToList();
            team.Blog = context.Blogs.FirstOrDefault();
            team.Teams = context.Teams.Include("Position").ToList();
            return View(team);
        }
    }
}