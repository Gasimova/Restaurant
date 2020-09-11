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
    public class PositionController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Position
        public ActionResult Index()
        {
            List<Position> positions = context.Positions.ToList();
            return View(positions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                context.Positions.Add(position);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }


        public ActionResult Edit(int Id)
        {
            Position position = context.Positions.Find(Id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        [HttpPost]
        public ActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                context.Entry(position).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        public ActionResult Delete(int Id)
        {
            Position position = context.Positions.Find(Id);
            if (position==null)
            {
                return HttpNotFound();
            }
            context.Positions.Remove(position);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}