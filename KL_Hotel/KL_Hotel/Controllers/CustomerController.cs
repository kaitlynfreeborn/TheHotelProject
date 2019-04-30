﻿using System;
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
        public ActionResult CustIndex()
        {
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
            List<Customer> customer = customerBusiness.Customers.ToList();
            return View(customer);
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
                OleDbConnection oleDbConnection = new OleDbConnection(connStr);
                oleDbConnection.Open();

                OleDbCommand com = new OleDbCommand("SELECT * FROM Login WHERE [User_ID] ='" + UserName
                    + "' AND [Password]='" + Password + "'", oleDbConnection);

                OleDbDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    Response.Write("Welcome user");
                //store the login into seession id like global variable, and check my acct page for controller whether there is a value and if yes sho info for that account
                }
                else
                {
                    Response.Write("Invalid username/password");

                }
                return RedirectToAction("CustIndex");

            //String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            //using (SqlConnection sqlCon = new SqlConnection("SELECT * FROM Login WHERE [User_ID] ='" + UserName
            //+ "' AND [Password]='" + Password + "'", sqlCon))
            //{

            //    SqlDataReader reader = com.ExecuteReader();
            //    //read the info from the database table customer and store it in reader object
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Customer customer = new Customer
            //        {
            //            CustomerID = Convert.ToInt32(reader[0]),
            //            UserName = reader[1].ToString(),
            //            Password = reader[2].ToString()
            //        };
            //        if (reader.HasRows)
            //        {
            //            Response.Write("Welcome user");
            //            //store the login into seession id like global variable, and check my acct page for controller whether there is a value and if yes sho info for that account
            //        }
            //        else
            //        {
            //            Response.Write("Invalid username/password");

            //        }

            //        //open the connection
            //        sqlCon.Open();
            //        //execute the procedure
            //        command.ExecuteNonQuery();

            //        return RedirectToAction("CustIndex");

                }
            }
}