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
    public class ReservationController : Controller
    {
        VincentContext context = new VincentContext();
        // GET: AdminPanel/Reservation
        public ActionResult Index()
        {
            List<Reservation> reservations = context.Reservations.ToList();
            return View(reservations);
        }
    }
}