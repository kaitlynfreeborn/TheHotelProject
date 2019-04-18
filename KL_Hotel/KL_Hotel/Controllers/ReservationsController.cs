using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_Hotel.Controllers
{
    public class ReservationsController : Controller
    {
        // GET: Reservations
        public ActionResult Index()
        {
            return View();
        }
    }
}