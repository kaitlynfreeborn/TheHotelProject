using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_Hotel.Models;


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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string firstName, string lastName, int user_ID, string password)
        {
            customerBusinessLayer customerBusiness = new customerBusinessLayer();
            Customer cust = new Customer();
            cust.FirstName = firstName;
            cust.LastName = lastName;
            cust.User_ID = user_ID;
            cust.Password = password;

            //call the method in the business layer
            customerBusiness.AddCustomer(cust);

            return RedirectToAction("Index");


        }
    }
}