using _17BangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            RegisterModels model = new RegisterModels
            {
                Name = "刘伟",
                Password = "1234"
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RegisterModels model)
        {

            return View();
        }
    }
}