using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;
using SRV.ViewModel.Log;

namespace _17BangMVC.Controllers
{
    public class LogController : Controller
    {
        private IUserService userService;

        public LogController(IUserService service)
        {
            userService = service;
        }

        public ActionResult On()
        {
            if (TempData[Keys.ErrorInModel] != null)
            {
                ModelState.Merge(TempData[Keys.ErrorInModel] as ModelStateDictionary);
            }

            return View();
        }

        [HttpPost]
        public ActionResult On(LogModel model)
        {

            if (model.InputImageCode.ToUpper() != Session[Keys.ImageCode].ToString())
            {
                ModelState.AddModelError(nameof(model.InputImageCode), "*  验证码错误");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(On));
            }
            UserModel user = userService.GetByName(model.Name);
            if (user == null)
            {
                ModelState.AddModelError(nameof(model.Name), "*  用户名不存在");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(On));
            }
            if (user.Password != Tool.MD5Crytp(model.Password))
            {
                ModelState.AddModelError(nameof(model.Password), "*  用户名或密码错误");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(On));
            }

            HttpCookie cookie = new HttpCookie(Keys.User);

            if (model.RememberMe == true)
            {
                cookie.Expires = DateTime.Now.AddDays(14);
            }
            cookie.Values.Add(Keys.Id, user.Id.ToString());
            cookie.Values.Add(Keys.Password, user.Password);
            Response.Cookies.Add(cookie);



            return RedirectToAction(nameof(On));
        }

        public ActionResult Off()
        {
            HttpCookie cookei = new HttpCookie(Keys.User);
            cookei.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookei);

            //发起请求的页面
            string urlReferrer = Convert.ToString(Request.UrlReferrer);
            if (string.IsNullOrEmpty(urlReferrer))
            {

            }

            return RedirectPermanent("/Register");
        }



    }
}