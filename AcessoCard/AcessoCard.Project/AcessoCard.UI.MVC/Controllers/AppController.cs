﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcessoCard.UI.MVC.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Contatos()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();

        }
    }
}