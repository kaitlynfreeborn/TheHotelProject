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
            ReservationBusinessLayer customerBusiness = new ReservationBusinessLayer();
            List<Reservations> reservations = customerBusiness.Reservations.ToList();
            return View(reservations);
        }

        [HttpGet]
        public ActionResult BookReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookReservation(DateTime StartDate, DateTime EndDate, string RoomType)
        {

            Reservations res = new Reservations
            {
                StartDate = StartDate,
                EndDate = EndDate,
                RoomType = RoomType
            };

            ReservationBusinessLayer customerBusiness = new ReservationBusinessLayer();
            
            //call the method in the business layer
            customerBusiness.AddReservation(res);

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
        public ActionResult Edit(int id, string firstName, string lastName, string userName, string password)
        {
            Customer cust = new Customer()
            {
                CustomerID = id,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            CustomerBusinessLayer cbl = new CustomerBusinessLayer();
            cbl.EditCustomer(cust);

            return RedirectToAction("ResIndex");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ReservationBusinessLayer cbl = new ReservationBusinessLayer();

            //fetches all the values into the specific object with customer(gets all info so don't have to type it all out)
            Reservations reservation  = cbl.Reservations.Single(res => res.ReservationID == id);

            return View(reservation);
        }


        [HttpPost]
        public ActionResult Delete(int id, string confirmdelete)
        {
            Reservations res = new Reservations()
            {
                ReservationID = id,

            };

            ReservationBusinessLayer cbl = new ReservationBusinessLayer();
            cbl.DeleteReservation(res);

            return RedirectToAction("ResIndex");
        }
        [HttpGet]

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string UserName, string Password)
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
            return RedirectToAction("ResIndex");


        }
    }
}
