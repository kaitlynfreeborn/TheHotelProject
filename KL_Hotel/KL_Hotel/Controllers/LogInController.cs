﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL_Hotel.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
    }
    [HttpPost]
    public ActionResult IndexLogInModel model)
    {
         cbe = new ConsumerBankingEntities();
        var s = cbe.GetCBLoginInfo(model.UserName, model.Password);

        var item = s.FirstOrDefault();
        if (item == "Success")
        {

            return View("UserLandingView");
        }
        else if (item == "User Does not Exists")

        {
            ViewBag.NotValidUser = item;

        }
        else
        {
            ViewBag.Failedcount = item;
        }

        return View("Index");
    }
}