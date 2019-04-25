using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL_Hotel.Models
{
    public class Reservations
    {
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomType { get; set; }

    }
}