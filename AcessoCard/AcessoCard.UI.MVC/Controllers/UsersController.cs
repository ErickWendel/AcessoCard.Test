using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcessoCard.Models;

namespace AcessoCard.UI.MVC.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult RecuperarSenha()
        {
            return View();

        }

        public ActionResult AlterarSenha()
        {
            return View();

        }


        
    }
}