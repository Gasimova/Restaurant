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
    public class AccordionController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Accordion
        public ActionResult Index()
        {
            List<Accordion> accordions = context.Accordions.ToList();
            return View(accordions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Accordion accordion)
        {
            if (ModelState.IsValid)
            {
                context.Accordions.Add(accordion);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accordion);
        }

        public ActionResult Edit(int Id)
        {
            Accordion accordion = context.Accordions.Find(Id);
            if (accordion == null)
            {
                return HttpNotFound();
            }
            return View(accordion);
        }

        [HttpPost]
        public ActionResult Edit(Accordion accordion)
        {
            if (ModelState.IsValid)
            {
                context.Entry(accordion).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accordion);
        }

        public ActionResult Delete(int Id)
        {
            Accordion accordion = context.Accordions.Find(Id);
            if (accordion == null)
            {
                return HttpNotFound();
            }

            context.Accordions.Remove(accordion);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}