using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_Hotel.Models;

namespace KL_Hotel.Models
{
    public class ReservationsController : Controller
    {
        //Get Reservation
        public ActionResult ResIndex()
        {
            ReservationBusinessLayer reservationBusiness = new ReservationBusinessLayer();
            List<Reservations> reservations = reservationBusiness.Reservations.ToList();
            return View(reservations);
        }

        [HttpGet]
        public ActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReservation(DateTime StartDate, DateTime EndDate, string RoomType)
        {

            Reservations res = new Reservations
            {
                StartDate = StartDate,
                EndDate = EndDate,
                RoomType = RoomType
            };

            ReservationBusinessLayer reservationBusiness = new ReservationBusinessLayer();

            //call the method in the business layer
            reservationBusiness.AddReservation(res);

            return RedirectToAction("ResIndex");


        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ReservationBusinessLayer cbl = new ReservationBusinessLayer();

            //fetches all the values into the specific object with customer (gets all info so don't have to type it all out)
           Reservations reservation = cbl.Reservations.Single(res => res.ReservationID == id);

            return View(reservation);
        }


        [HttpPost]
        public ActionResult Edit(int id, int cid, DateTime sDate, DateTime eDate, String roomType)
        {
            Reservations res = new Reservations()
            {
                ReservationID = id,
                CustomerID = cid,
                StartDate = sDate,
                EndDate = eDate,
                RoomType = roomType
            };

            ReservationBusinessLayer rbl = new ReservationBusinessLayer();
            rbl.EditReservation(res);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ReservationBusinessLayer rbl = new ReservationBusinessLayer();

            //fetches all the values into the specific object with customer(gets all info so don't have to type it all out)
            Reservations reservation  = rbl.Reservations.Single(res => res.ReservationID == id);

            return View(reservation);
        }


        [HttpPost]
        public ActionResult Delete(int id, string confirmdelete)
        {
            Reservations res = new Reservations()
            {
                ReservationID = id,

            };

            ReservationBusinessLayer rbl = new ReservationBusinessLayer();
            rbl.DeleteReservation(res);

            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {

            string connStr = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            OleDbConnection oleDbConnection = new OleDbConnection(connStr);
            oleDbConnection.Open();

            OleDbCommand com = new OleDbCommand("SELECT * FROM Login WHERE [User_ID] ='" + UserName
                + "' AND [Password]='" + Password + "'", oleDbConnection);

            OleDbDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                Response.Write("Welcome user");

            }
            else
            {
                Response.Write("Invalid username/password");

            }
            return RedirectToAction("Index");


        }
    }
}
