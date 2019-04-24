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
            
            Customer cust = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            customerBusinessLayer customerBusiness = new customerBusinessLayer();

            //call the method in the business layer
            customerBusiness.AddCustomer(cust);

            return RedirectToAction("Index");


        }

        
        [HttpGet]
        public ActionResult Login()
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