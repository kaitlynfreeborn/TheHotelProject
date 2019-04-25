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
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
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
            
            Customer cust = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();

            //call the method in the business layer
            customerBusiness.AddCustomer(cust);

            return RedirectToAction("Index");


        }

        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer cbl = new CustomerBusinessLayer();

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

            CustomerBusinessLayer cbl = new CustomerBusinessLayer();
            cbl.EditCustomer(cust);

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