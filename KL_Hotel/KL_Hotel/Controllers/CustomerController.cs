using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string firstName, string lastName, int user_ID, string password)
        {
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
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