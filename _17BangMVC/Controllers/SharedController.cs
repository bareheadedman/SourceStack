using GLB.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Controllers
{
    public class SharedController : Controller
    {

        public ActionResult GetImageCode()
        {

            string imageCode = Tool.ImageCode(4);
            byte[] img = Tool.CreateImageCode(imageCode);
            Session.Add(Keys.ImageCode, imageCode);
            return File(img, @"image/jpeg");
        }
    }
}