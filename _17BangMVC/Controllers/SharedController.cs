using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Controllers
{
    public class SharedController : Controller
    {
        private IUserService userService;

        public SharedController(IUserService service)
        {
            userService = service;
        }

        public ActionResult GetImageCode()
        {

            string imageCode = Tool.ImageCode(4);
            byte[] img = Tool.CreateImageCode(imageCode);
            Session.Add(Keys.ImageCode, imageCode);
            return File(img, @"image/jpeg");
        }


        public ActionResult _NavigationBars()
        {
            UserModel user = userService.GetCurrentUserAsModel();
            return PartialView(user);
        }
    }
}