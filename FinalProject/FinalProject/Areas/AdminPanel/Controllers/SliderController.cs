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
    public class SliderController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Slider
        public ActionResult Index()
        {
            List<Slider> sliders = context.Sliders.ToList();
            return View(sliders);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(slider);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                slider.ImageFile.SaveAs(imgPath);
                slider.Image = imgName;

                context.Sliders.Add(slider);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        public ActionResult Edit(int Id)
        {
            Slider slider = context.Sliders.Find(Id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HttpPost]
        public ActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                Slider slider1 = context.Sliders.Find(slider.Id);

                if (slider.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + slider.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);


                    string oldPath1 = Path.Combine(Server.MapPath("~/Uploads/"), slider1.Image);
                    System.IO.File.Delete(oldPath1);


                    slider.ImageFile.SaveAs(imgPath);
                    slider1.Image = imgName;
                }

                slider1.Subtitle = slider.Subtitle;
                slider1.Title = slider.Title;
                slider1.Type = slider.Type;
                slider1.Description = slider.Description;

                context.Entry(slider1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        public ActionResult Delete(int Id)
        {
            Slider slider = context.Sliders.Find(Id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            context.Sliders.Remove(slider);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}