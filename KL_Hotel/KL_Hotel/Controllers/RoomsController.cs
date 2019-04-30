using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_Hotel.Models;

namespace KL_Hotel.Controllers
{
    public class RoomsController : Controller
    {
        // GET: Rooms
        public ActionResult RoomsIndex()
        {
            Rooms King = new Rooms()
            {
                RoomType = "King Suite",
                RoomDescription = "One king bed, and other amenities",
                RoomImage = @"https://hiltongardeninn3.hilton.com/resources/media/gi/OKCNOGI/en_US/img/shared/full_page_image_gallery/main/GI_king001_7_698x390_FitToBoxSmallDimension_Center.jpg"
            };

            Rooms Queen = new Rooms()
            {
                RoomType = "Queen Suite",
                RoomDescription = "Two queen beds, and other amenities",
                RoomImage = @"https://hiltongardeninn3.hilton.com/resources/media/gi/OKCNOGI/en_US/img/shared/full_page_image_gallery/main/GI_dblqueen001_5_698x390_FitToBoxSmallDimension_Center.jpg"
            };

            List<Rooms> rm = new List<Rooms>();
            rm.Add(King);
            rm.Add(Queen);


            return View(rm);
        }

    }

}