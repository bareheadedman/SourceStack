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
        private IKeywordService keywordService;

        public SharedController(IUserService userService, IKeywordService keywordService)
        {
            this.userService = userService;
            this.keywordService = keywordService;
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


        [HttpPost]
        public ActionResult SelectedKeyword(int? level, string name)
        {

            if (level!=null)
            {
                return PartialView(keywordService.GetByLevel((int)level));

            } // else nothing

            if (name != null)
            {
                return PartialView(keywordService.GetByNameToDownLevel(name));
            }// else nothing


            return PartialView(null);
        }



    }
}