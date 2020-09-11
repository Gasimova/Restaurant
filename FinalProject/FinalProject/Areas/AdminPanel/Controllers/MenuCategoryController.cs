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
    public class MenuCategoryController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/MenuCategory
        public ActionResult Index()
        {
            List<MenuCategory> menuCategories = context.MenuCategories.ToList();
            return View(menuCategories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuCategory menu)
        {
            if (ModelState.IsValid)
            {
                context.MenuCategories.Add(menu);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(menu);
        }

        public ActionResult Edit(int Id)
        {
            MenuCategory menu = context.MenuCategories.Find(Id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(MenuCategory menu)
        {
            if (ModelState.IsValid)
            {
                context.Entry(menu).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        public ActionResult Delete(int Id)
        {
            MenuCategory menu = context.MenuCategories.Find(Id);
            if (menu == null)
            {
                return HttpNotFound();
            }

            context.MenuCategories.Remove(menu);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}