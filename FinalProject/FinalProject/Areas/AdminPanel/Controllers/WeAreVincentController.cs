using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class WeAreVincentController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/WeAreVincent
        public ActionResult Index()
        {
            List<WeAreVincent> weAreVincents = context.WeAreVincents.ToList();
            return View(weAreVincents);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WeAreVincent vincent)
        {
            if (ModelState.IsValid)
            {
                if (vincent.Image1File == null && vincent.Image2File==null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(vincent);
                }

                string imgName1 = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + vincent.Image1File.FileName;
                string imgName2 = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + vincent.Image2File.FileName;

                string imgPath1 = Path.Combine(Server.MapPath("~/Uploads/"), imgName1);
                string imgPath2 = Path.Combine(Server.MapPath("~/Uploads/"), imgName2);

                vincent.Image1File.SaveAs(imgPath1);
                vincent.Image1 = imgName1;
                vincent.Image2File.SaveAs(imgPath2);
                vincent.Image2 = imgName2;

                context.WeAreVincents.Add(vincent);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vincent);
        }

        public ActionResult Edit(int Id)
        {
            WeAreVincent vincent = context.WeAreVincents.Find(Id);
            if (vincent == null)
            {
                return HttpNotFound();
            }
            return View(vincent);
        }

        [HttpPost]
        public ActionResult Edit(WeAreVincent vincent)
        {
            if (ModelState.IsValid)
            {
                WeAreVincent vincent1 = context.WeAreVincents.Find(vincent.Id);

                if(vincent.Image1File!=null )
                {
                    string imgName1 = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + vincent.Image1File.FileName;
                    string imgPath1 = Path.Combine(Server.MapPath("~/Uploads/"), imgName1);

                    string oldPath1 = Path.Combine(Server.MapPath("~/Uploads/"), vincent1.Image1);
                    System.IO.File.Delete(oldPath1);

                    vincent.Image1File.SaveAs(imgPath1);
                    vincent1.Image1 = imgName1;
                }

                if (vincent.Image2File != null)
                {
                    string imgName2 = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + vincent.Image2File.FileName;
                    string imgPath2 = Path.Combine(Server.MapPath("~/Uploads/"), imgName2);

                    string oldPath2 = Path.Combine(Server.MapPath("~/Uploads/"), vincent1.Image2);
                    System.IO.File.Delete(oldPath2);

                    vincent.Image2File.SaveAs(imgPath2);
                    vincent1.Image2 = imgName2;
                }


                vincent1.Title = vincent.Title;
                vincent1.SubTitle = vincent.SubTitle;
                vincent1.Text = vincent.Text;

                context.Entry(vincent1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vincent);
        }

        public ActionResult Delete(int Id)
        {
            WeAreVincent vincent = context.WeAreVincents.Find(Id);
            if (vincent==null)
            {
                return HttpNotFound();
            }

            context.WeAreVincents.Remove(vincent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}