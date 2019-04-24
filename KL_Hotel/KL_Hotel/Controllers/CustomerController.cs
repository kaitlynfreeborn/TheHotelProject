using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_Hotel.Models;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;



namespace KL_Hotel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            customerBusinessLayer customerBusiness = new customerBusinessLayer();
            List<Customer> customer = customerBusiness.Customers.ToList();
            return View(customer);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string userName, string password)
        {
            customerBusinessLayer customerBusiness = new customerBusinessLayer();
            Customer cust = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            //call the method in the business layer
            customerBusiness.AddCustomer(cust);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            customerBusinessLayer cbl = new customerBusinessLayer();

            //fetches all the values into the specific object with customer (gets all info so don't have to type it all out)
            Customer customer = cbl.Customers.Single(cust => cust.CustomerID == id);

            return View(customer);
        }


        [HttpPost]
        public ActionResult Edit(int id, string FirstName, string LastName, string UserName, string Password)
        {
            Customer cust = new Customer()
            {
                CustomerID = id,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password
            };

            customerBusinessLayer cbl = new customerBusinessLayer();
            cbl.EditCustomer(cust);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            customerBusinessLayer cbl = new customerBusinessLayer();

            //fetches all the values into the specific object with customer (gets all info so don't have to type it all out)
            Customer customer = cbl.Customers.Single(cust => cust.CustomerID == id);

            return View(customer);
        }


        [HttpPost]
        public ActionResult Delete(int id, string confirmdelete)
        {
            Customer cust = new Customer()
            {
                CustomerID = id,

            };

            customerBusinessLayer cbl = new customerBusinessLayer();
            cbl.DeleteCustomer(cust);

            return RedirectToAction("Index");
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
                return RedirectToAction("Index");


        }
    }
}