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
    }
}