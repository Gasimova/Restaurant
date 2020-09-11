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
    public class ReviewsController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Reviews
        public ActionResult Index()
        {
            List<Review> reviews = context.Reviews.ToList();
            return View(reviews);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                if (review.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(review);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + review.ImageFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                review.ImageFile.SaveAs(imgPath);
                review.Image = imgName;

                context.Reviews.Add(review);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        public ActionResult Edit(int Id)
        {
            Review review = context.Reviews.Find(Id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }


        [HttpPost]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                Review review1 = context.Reviews.Find(review.Id);
                if (review.ImageFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + review.ImageFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), review1.Image);
                    System.IO.File.Delete(oldPath);

                    review.ImageFile.SaveAs(imgPath);
                    review1.Image = imgName;

                }

                review1.Name = review.Name;
                review1.Position = review.Position;
                review1.Reviews = review.Reviews;
                review1.Surname = review.Surname;


                context.Entry(review1).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        public ActionResult Delete(int Id)
        {
            Review review = context.Reviews.Find(Id);
            if (review == null)
            {
                return HttpNotFound();
            }

            context.Reviews.Remove(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}