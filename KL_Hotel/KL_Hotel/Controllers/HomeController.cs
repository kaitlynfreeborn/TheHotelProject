using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_Hotel.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult HomeIndex()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    
        public ActionResult About()
            {
            ViewBag.Title = "About Page";

                return View();
            }

        public ActionResult Contact()
        {
            ViewBag.Tite = "Contact";

            return View();
        }
    }
}
