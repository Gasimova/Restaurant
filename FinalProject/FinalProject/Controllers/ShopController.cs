using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Shop
        public ActionResult Index(int page=1)
        {
            ViewBag.setting = context.Settings.FirstOrDefault();
            vmShop shop = new vmShop();
            #region Card
            HttpCookie cookie = Request.Cookies["Card"];
            if (cookie != null)
            {
                List<string> Card = cookie.Value.Split(',').ToList();
                Card.RemoveAt(Card.Count-1);

                ViewBag.Menu = context.Menus.ToList().Where(c => Card.Contains(c.Id.ToString()) == true).ToList();

                shop.Card = Card;

                ViewBag.Card = Card;
                ViewBag.CardCount = Card.Count;

            }
            else
            {
                ViewBag.CardCount = 0;
            }
            #endregion
           

            shop.Menus = context.Menus.OrderByDescending(o => o.Id).Skip((page - 1) * 12).Take(12).ToList();
            shop.MenuCategories = context.MenuCategories.ToList();
            shop.Tags = context.Tags.ToList();
            shop.CurrentPage = page;
            shop.PageCount = Convert.ToInt32(Math.Ceiling(context.Menus.Count() / 12.0));
            return View(shop);
        }


        public JsonResult AddToCard(int? id)
        {
            vmCard vmCard = new vmCard();
            HttpCookie cookie2 = Request.Cookies["Card"];
            List<string> Card = new List<string>();
            if (Request.Cookies["Card"] != null)
            {
                Card = cookie2.Value.Split(',').ToList();
                Card.RemoveAt(Card.Count - 1);
            }


            if (id != null)
            {
                if (Request.Cookies["Card"] != null)
                {
                    string oldList = Request.Cookies["Card"].Value;
                    List<string> oldListArr = oldList.Split(',').ToList();

                    HttpCookie cookie = new HttpCookie("Card");
                    cookie.Value = oldList;
                    if (!oldListArr.Any(c => c == id.ToString()))
                    {
                        cookie.Value += id + ",";
                        Card.Add(id.ToString());
                        Request.Cookies["Card"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        vmCard.Response = "success-true";
                    }
                    else
                    {
                        oldListArr.Remove(id.ToString());
                        Card.Remove(id.ToString());

                        oldList = string.Join(",", oldListArr);
                        cookie.Value = oldList;
                        Request.Cookies["Card"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        vmCard.Response = "success-false";
                    }
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("Card");

                    cookie.Expires = DateTime.Now.AddYears(1);
                    cookie.Value += id + ",";
                    Card.Add(id.ToString());
                    Response.Cookies.Add(cookie);
                    vmCard.Response = "success-true";
                }
            }
            else
            {
                vmCard.Response = "error";
            }

            #region Card

            if (Request.Cookies["Card"] != null)
            {
                vmCard.Menu = context.Menus.ToList().Where(m => Card.Any(c => Convert.ToInt32(c) == m.Id)).ToList();
            }
            #endregion

            return Json(vmCard, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveFromCookie(int? id)
        {
            string response = "";
            if (id != null)
            {

                string oldList = Request.Cookies["Card"].Value;
                    HttpCookie cookie = new HttpCookie("Card");
                    cookie.Value = oldList;

                  
                        List<string> oldListArr = oldList.Split(',').ToList();
                        oldListArr.Remove(id.ToString());

                        oldList = string.Join(",", oldListArr);
                        cookie.Value = oldList;
                        Request.Cookies["Card"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        response = "success-false";

                         oldList = string.Join(",", oldListArr);
                        cookie.Value = oldList;
                        Request.Cookies["Card"].Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(cookie);
                        response = "success-false";
             }
            else
            {
                response = "error";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SelectMenu(int Id)
        {
           var menu = context.Menus.Include("MenuCategory").OrderBy(o=>o.Id).Where(m=>m.MenuCategoryId==Id).Select(s=> new { 
                s.Id,
                s.Name,
                s.Price,
                s.Weight,
                s.Image,
                s.Description,
                s.Dimentions,
                s.MenuCategoryId
                                 }).ToList();
           
            return Json(menu,JsonRequestBehavior.AllowGet);
        }

        public JsonResult PriceFilter(decimal Price)
        {
            //var page = 1;
            //var pageCount = Convert.ToInt32(Math.Ceiling(context.Menus.Count() / 12.0));

            var menu = context.Menus.Include("MenuCategory").OrderBy(o => o.Id).Where(p=>p.Price<=Price).Select(s => new {
                s.Id,
                s.Name,
                s.Price,
                s.Weight,
                s.Image,
                s.Description,
                s.Dimentions,
                s.MenuCategoryId
                                 }).ToList();

            return Json(menu, JsonRequestBehavior.AllowGet);
        }

       

       
    }
}