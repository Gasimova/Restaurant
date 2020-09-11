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
    public class TeamController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Team
        public ActionResult Index()
        {
            List<Team> team = context.Teams.ToList();
            return View(team);
        }

        public ActionResult Create()
        {
            ViewBag.Position = context.Positions.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                Team team1 = new Team();
                if (team.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.Position = context.Positions.ToList();
                    return View(team);
                }
                else
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + team.ImageFile.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    team.ImageFile.SaveAs(path);
                    team1.Image = imgName;
                }

                team1.PositionId = team.PositionId;
                team1.Name = team.Name;
                team1.Surname = team.Surname;
                team1.Twitter = team.Twitter;
                team1.Facebook = team.Facebook;
                team1.Instagram = team.Instagram;
                

                context.Teams.Add(team1);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Position = context.Positions.ToList();
            return View(team);
        }


        public ActionResult Edit(int Id)
        {
            ViewBag.Position = context.Positions.ToList();
            Team team = context.Teams.Find(Id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }


        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                Team team1 = context.Teams.Find(team.Id);
                if (team.ImageFile!=null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + team.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), team1.Image);
                    System.IO.File.Delete(oldPath);

                    team.ImageFile.SaveAs(imgPath);
                    team1.Image = imgName;
                }

                team1.Instagram = team.Instagram;
                team1.Name = team.Name;
                team1.Surname = team.Surname;
                team1.Twitter = team.Twitter;

                context.Entry(team1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ViewBag.Position = context.Positions.ToList();
            return View(team);
        }

        public ActionResult Delete(int Id)
        {
            Team team = context.Teams.Find(Id);
            if (team == null)
            {
                return HttpNotFound();
            }

            context.Teams.Remove(team);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}