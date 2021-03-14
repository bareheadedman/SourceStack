using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (level != null)
            {
                return PartialView(keywordService.GetByLevel((int)level));

            } // else nothing

            if (name != null)
            {
                return PartialView(keywordService.GetByNameToDownLevel(name));
            }// else nothing


            return PartialView(null);
        }


        [HttpPost]
        public ActionResult ImagePreview()
        {
            HttpPostedFileBase icon = Request.Files[0];
            if (icon.ContentLength > (1024 * 256))
            {
                ModelState.AddModelError("icon", "* 上传的图片大小不能超过256KB");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectPermanent("/Profile/Write");
            }
            if (icon.ContentType != "image/jpg" && icon.ContentType != "image/png" && icon.ContentType != "image/gif" && icon.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("icon", "* 上传的图片格式只能为 png/jpg/jpeg/gif");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectPermanent("/Profile/Write");
            }

            DateTime now = DateTime.Now;

            string urlPath = $"\\UpLoadFiles\\{now.Year}\\{now.Month}\\{now.Day}";
            Guid guid = Guid.NewGuid();
            string extension = Path.GetExtension(icon.FileName);
            string urlName = $"{urlPath}\\{guid}{extension}";

            Directory.CreateDirectory(Server.MapPath(urlPath));
            icon.SaveAs(Server.MapPath(urlName));

            userService.SaveIconPathToUser(userService.GetCurrentUserAsModel().Id, urlName);



            return Json(urlName);
        }


    }
}