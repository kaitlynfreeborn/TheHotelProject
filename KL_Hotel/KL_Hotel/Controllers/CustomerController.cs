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
using System.Data.SqlClient;

namespace KL_Hotel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustIndex()
        {
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
            //List<Customer> customer = customerBusiness.getCustomer.ToList();
            return View();
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

            return RedirectToAction("CustIndex");


        }

        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer cbl = new CustomerBusinessLayer();

            //fetches all the values into the specific object with customer (gets all info so don't have to type it all out)
            Customer customer = cbl.getCustomerDetails.Single(cust => cust.CustomerID == id);

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

            return RedirectToAction("CustIndex");
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
                SqlConnection oleDbConnection = new SqlConnection(connStr);
                oleDbConnection.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM Login WHERE [User_ID] ='" + UserName
                    + "' AND [Password]='" + Password + "'", SqlConnection);

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    Response.Write("Welcome user");

                }
                else
                {
                    Response.Write("Invalid username/password");

                }
                return RedirectToAction("CustIndex");


        }
    }
}