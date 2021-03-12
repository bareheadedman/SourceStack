using SRV.ViewModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Controllers
{
    public class ProfileController : Controller
    {

        public ActionResult Write()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Write(WriteModel model)
        {
            return View();
        }
    }
}