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
    public class SettingsController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Settings
        public ActionResult Index()
        {
            List<Setting> settings = context.Settings.ToList();
            return View(settings);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                string headerLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.HeaderLogoFile.FileName;
                string headerLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), headerLogoName);

                string footerLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.FooterLogoFile.FileName;
                string footerLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), footerLogoName);

                string masterCardName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.MasterCardFile.FileName;
                string masterCardPath = Path.Combine(Server.MapPath("~/Uploads/"), masterCardName);

                string visaName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.VisaFile.FileName;
                string visaPath = Path.Combine(Server.MapPath("~/Uploads/"), visaName);



                setting.HeaderLogoFile.SaveAs(headerLogoPath);
                setting.FooterLogoFile.SaveAs(footerLogoPath);
                setting.MasterCardFile.SaveAs(masterCardPath);
                setting.VisaFile.SaveAs(visaPath);

                setting.HeaderLogo = headerLogoName;
                setting.FooterLogo = footerLogoName;
                setting.MasterCard = masterCardName;
                setting.Visa = visaName;

                context.Settings.Add(setting);
                context.SaveChanges();

                return RedirectToAction("Index");

                }
            return View(setting);
        }

        public ActionResult Edit(int Id)
        {
            Setting setting = context.Settings.Find(Id);
            if (setting == null)
            {
                return HttpNotFound();
            }

            return View(setting);
        }


        [HttpPost]
        public ActionResult Edit(Setting setting)
        {
            if (ModelState.IsValid)
            {
                Setting setting1 = new Setting();

                if (setting.HeaderLogoFile!=null)
                {
                    string headerLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.HeaderLogoFile.FileName;
                    string headerLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), headerLogoName);

                    string oldHeaderPath = Path.Combine(Server.MapPath("~/Uploads/"), setting1.HeaderLogo);
                    System.IO.File.Delete(oldHeaderPath);

                    setting.HeaderLogoFile.SaveAs(headerLogoPath);
                    setting1.HeaderLogo = headerLogoName;
                }

                if (setting.FooterLogoFile != null)
                {
                    string footerLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.FooterLogoFile.FileName;
                    string footerLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), footerLogoName);

                    string oldFooterPath = Path.Combine(Server.MapPath("~/Uploads/"), setting1.FooterLogo);
                    System.IO.File.Delete(oldFooterPath);

                    setting.FooterLogoFile.SaveAs(footerLogoPath);
                    setting1.FooterLogo = footerLogoName;
                }

                if (setting.MasterCardFile != null)
                {
                    string masterCardName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.MasterCardFile.FileName;
                    string masterCardPath = Path.Combine(Server.MapPath("~/Uploads/"), masterCardName);

                    string oldMasterPath = Path.Combine(Server.MapPath("~/Uploads/"), setting1.MasterCard);
                    System.IO.File.Delete(oldMasterPath);

                    setting.MasterCardFile.SaveAs(masterCardPath);
                    setting1.MasterCard = masterCardName;
                }

                if (setting.VisaFile != null)
                {
                    string visaName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.VisaFile.FileName;
                    string visaPath = Path.Combine(Server.MapPath("~/Uploads/"), visaName);

                    string oldVisaPath = Path.Combine(Server.MapPath("~/Uploads/"), setting1.Visa);
                    System.IO.File.Delete(oldVisaPath);

                    setting.VisaFile.SaveAs(visaPath);
                    setting1.Visa = visaName;
                }

                setting1.Facebook = setting.Facebook;
                setting1.Instagram = setting.Instagram;
                setting1.Phone =(int)setting.Phone;
                setting1.Twitter = setting.Twitter;
                setting1.Weekday = setting.Weekday;
                setting1.Weekend = setting.Weekend;

                context.Entry(setting1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        public ActionResult Delete(int Id)
        {
            Setting setting = context.Settings.Find(Id);
            if (setting == null)
            {
                return HttpNotFound();
            }

            context.Settings.Remove(setting);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}