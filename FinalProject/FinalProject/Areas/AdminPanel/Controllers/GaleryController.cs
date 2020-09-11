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
    public class GaleryController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Galery
        public ActionResult Index()
        {
            List<Galery> galeries = context.Galeries.ToList();
            return View(galeries);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Galery galery)
        {
            if (ModelState.IsValid)
            {
                if (galery.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(galery);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + galery.ImageFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                galery.ImageFile.SaveAs(imgPath);
                galery.Image = imgName;

                context.Galeries.Add(galery);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galery);
        }

        public ActionResult Edit(int Id)
        {
            Galery galery = context.Galeries.Find(Id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }


        [HttpPost]
        public ActionResult Edit(Galery galery)
        {
            if (ModelState.IsValid)
            {
                Galery galery1 = context.Galeries.Find(galery.Id);
                if (galery.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + galery.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), galery1.Image);
                    System.IO.File.Delete(oldPath);

                    galery.ImageFile.SaveAs(imgPath);
                    galery1.Image = imgName;

                }

                

                context.Entry(galery1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galery);
        }

        public ActionResult Delete(int Id)
        {
            Galery galery = context.Galeries.Find(Id);
            if (galery == null)
            {
                return HttpNotFound();
            }

            context.Galeries.Remove(galery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}