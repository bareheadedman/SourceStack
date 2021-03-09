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
            byte[] img = Tool.CreateImageCode(Tool.ImageCode(4));

            return File(img, @"image/jpeg");
        }
    }
}