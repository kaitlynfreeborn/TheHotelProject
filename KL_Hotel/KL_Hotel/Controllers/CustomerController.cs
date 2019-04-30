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


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using KL_Hotel.Models;

namespace KL_Hotel.Controllers
{
    public class CustomerController : Controller
    {
        //var userData = HttpContext.Current.GetCustomUserDataObject();
        //GET: Customer
        public ActionResult CustIndex()
        {
            //    if (session has value)
            //            {
            //        return
            //            }
            string u;
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
            u = Session["UserName"].ToString();
            return View();
            //this should be where if session yes
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string userName, string password)
        {
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();

            Customer cust = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };


            //call the method in the business layer
            customerBusiness.AddCustomer(cust);

            return RedirectToAction("CustIndex");


        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerBusinessLayer cbl = new CustomerBusinessLayer();

            //fetches all the values into the specific object with customer (gets all info so don't have to type it all out)

            //Customer customer = cbl.CustomerData.Single(cust => cust.CustomerID == id);

            return View();
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

            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE [UserName] ='" + UserName
               + "' AND [Password]='" + Password + "'", con);

                //open the connection
                con.Open();

                //read the info from the database table customer and store it in reader object
                SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{

                //    Customer customer = new Customer
                //    {
                //        CustomerID = Convert.ToInt32(reader[0]),
                //        UserName = reader[1].ToString(),
                //        Password = reader[2].ToString()
                //    };
                if (reader.HasRows)
                {
                    Response.Write("Welcome user");
                    Session["UserName"] = UserName;
                    //store the login into seession id like global variable, and check my acct page for controller whether there is a value and if yes sho info for that account
                }
                else
                {
                    Response.Write("Invalid username/password");

                }



                //}
                // return RedirectToAction("CustIndex");
                return View();
            }
            // Session["UserID"] = firstName;
        }
    }
}





