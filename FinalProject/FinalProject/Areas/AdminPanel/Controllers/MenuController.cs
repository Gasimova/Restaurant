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
    public class MenuController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Menu
        public ActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        public ActionResult Create()
        {
            ViewBag.MenuCategory = context.MenuCategories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                Menu menu1 = new Menu();
                if (menu.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.MenuCategory = context.MenuCategories.ToList();
                    return View(menu);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + menu.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    menu.ImageFile.SaveAs(imagePath);
                    menu1.Image = imageName;

                }

                menu1.MenuCategoryId = menu.MenuCategoryId;
                menu1.Name = menu.Name;
                menu1.Price = menu.Price;
                menu1.Weight = menu.Weight;
                menu1.Dimentions = menu.Dimentions;
                menu1.Description = menu.Description;

                context.Menus.Add(menu1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuCategory = context.MenuCategories.ToList();
            return View(menu);
        }



        public ActionResult Edit(int Id)
        {
            Menu menu = context.Menus.Find(Id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuCategory = context.MenuCategories.ToList();
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                Menu menu1 = context.Menus.Find(menu.Id);

                if (menu.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + menu.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), menu1.Image);
                    System.IO.File.Delete(oldPath);

                    menu.ImageFile.SaveAs(imgPath);
                    menu1.Image = imgName;
                }

                menu1.Description = menu.Description;
                menu1.Dimentions = menu.Dimentions;
                menu1.Name = menu.Name;
                menu1.Price = menu.Price;
                menu1.Weight = menu.Weight;
                menu1.MenuCategoryId = menu.MenuCategoryId;

                context.Entry(menu1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.MenuCategory = context.MenuCategories.ToList();
            return View(menu);
        }

        public ActionResult Delete(int Id)
        {
            Menu menu = context.Menus.Find(Id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            context.Menus.Remove(menu);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}