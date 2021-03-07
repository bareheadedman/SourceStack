using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _17BangMVC.Filters;
using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;

namespace _17BangMVC.Controllers
{
    [ModelErrorTransferFilter]
    public class RegisterController : Controller
    {
        private IUserService userService;
        public RegisterController()
        {
            userService = new SRV.ProdService.UserService();
            //userService = new SRV.MockService.UserService();
        }


        public ActionResult Index()
        {
            if (TempData[Keys.ErrorInModel] != null)
            {
                ModelState.Merge(TempData[Keys.ErrorInModel] as ModelStateDictionary);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {


            if (!ModelState.IsValid)
            {
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(nameof(model.ConfirmPassword), "* 确认密码和密码不一致");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));

            }

            RegisterModel invitedby = userService.GetByName(model.InvitedName);
            if (invitedby == null)
            {
                ModelState.AddModelError(nameof(model.InvitedName), "* 邀请人不存在");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (invitedby.InvitedCode != model.InvitedCode)
            {
                ModelState.AddModelError(nameof(model.InvitedCode), "* 邀请码不正确");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (userService.GetByName(model.Name)!= null)
            {
                ModelState.AddModelError(nameof(model.Name), "*  用户名已存在");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            userService.Save(model);

            return View();
        }
    }
}