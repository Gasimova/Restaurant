using FinalProject.Areas.AdminPanel.Filter;
using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel.Controllers
{
    [Logout]
    public class MessageController : Controller
    {
        VincentContext context = new VincentContext();
         // GET: AdminPanel/Message
        public ActionResult Index()
        {
            List<Message> messages = context.Messages.Include("User").Include("Blog").ToList();
            return View(messages);
        }
    }
}