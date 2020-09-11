using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: Checkout
        public ActionResult Index(Menu[] menu)
        {
            ViewBag.setting = context.Settings.FirstOrDefault();

            vmCheckout checkout = new vmCheckout();
            checkout.Tags = context.Tags.ToList();
            checkout.BlogCategories = context.BlogCategories.ToList();
            checkout.InstaFeeds = context.InstaFeeds.ToList();
            checkout.Blogs = context.Blogs.ToList();


            HttpCookie cookie = Request.Cookies["Card"];

            if (cookie!=null)
            {
                List<string> Card = cookie.Value.Split(',').ToList();
                Card.RemoveAt(Card.Count - 1);

                ViewBag.Card = Card;
                ViewBag.CardCount = Card.Count;

                List<Menu> Menu = new List<Menu>();

                foreach (var item in menu)
                {
                    foreach (var item2 in context.Menus.ToList())
                    {
                        if (item2.Id == item.Id)
                        {
                            item2.Quantity = item.Quantity;
                            Menu.Add(item2);
                        }
                    }
                }
                checkout.Menus = Menu;

            }
            else
            {
                ViewBag.CardCount = 0;
            }

            return View(checkout);
        }


        public JsonResult PlaceOrder(vmOrderInfo orderInfo)
        {
            int userID;
            if (Session["LoginnerUser"]==null)
            {
                User user = new User();
                user.Name = orderInfo.Name;
                user.Surname = orderInfo.Surname;
                user.Username = orderInfo.Name;
                user.Address = orderInfo.Address;
                user.Phone = orderInfo.Phone;
                user.Email = orderInfo.Email;
                user.CreatedDate = DateTime.Now;

                context.Users.Add(user);
                context.SaveChanges();
                userID = user.Id;
            }
            else
            {
                userID = (int)Session["LoginnerUserId"];
            }

            //order info
            foreach (var item in orderInfo.ProductId)
            {
                decimal total = 0;
                Menu menu = context.Menus.Find(item);
                int index = orderInfo.ProductId.ToList().IndexOf(item);

                Order order = new Order();
                order.Quantity = orderInfo.ProductQuantity[index];
                total += menu.Price * order.Quantity;

                order.MenuId = item;
                order.UserId = userID;
                order.Price =total;
                order.CreatedDate = DateTime.Now;

                context.Orders.Add(order);
            }
            context.SaveChanges();

            HttpCookie cookieCard = Request.Cookies["Card"];
            cookieCard.Value = "0";
            Response.Cookies.Add(cookieCard);

            return Json("ok",JsonRequestBehavior.AllowGet);
        }

        
    }
}