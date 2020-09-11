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
    public class AddressController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Address
        public ActionResult Index()
        {
            List<Address> addresses = context.Addresses.ToList();
            return View(addresses);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                if (address.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(address);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + address.ImageFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                address.ImageFile.SaveAs(imgPath);
                address.Image = imgName;

                context.Addresses.Add(address);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        public ActionResult Edit(int Id)
        {
            Address address = context.Addresses.Find(Id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                Address address1 = context.Addresses.Find(address.Id);

                if (address.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + address.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);


                    string oldPath1 = Path.Combine(Server.MapPath("~/Uploads/"), address1.Image);
                    System.IO.File.Delete(oldPath1);


                    address.ImageFile.SaveAs(imgPath);
                    address1.Image = imgName;
                }

                address1.Email = address.Email;
                address1.Filial = address.Filial;
                address1.Map = address.Map;
                address1.Phone = address.Phone;
                address1.Street = address.Street;
                address1.Weekday = address.Weekday;
                address1.Weekend = address.Weekend;

                context.Entry(address1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        public ActionResult Delete(int Id)
        {
            Address address = context.Addresses.Find(Id);
            if (address == null)
            {
                return HttpNotFound();
            }

            context.Addresses.Remove(address);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}