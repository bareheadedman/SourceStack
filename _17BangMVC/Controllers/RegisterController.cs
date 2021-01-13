using _17BangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using BLL.Repositories;
using _17BangMVC.Filters;

namespace _17BangMVC.Controllers
{
    [ModelErrorTransferFilter]
    public class RegisterController : Controller
    {

        public ActionResult Index()
        {
            if (TempData[Keys.ErrorInModel] != null)
            {
                ModelState.Merge(TempData[Keys.ErrorInModel] as ModelStateDictionary);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModels model)
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
            User invitedby = new UserRepository(new SqlDbContext()).GetByName(model.InvitedName);
            if (invitedby == null)
            {
                ModelState.AddModelError(nameof(model.InvitedName), "* 邀请人不存在");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (invitedby.InviteCode != model.InvitedCode)
            {
                ModelState.AddModelError(nameof(model.InvitedCode), "* 邀请码不正确");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (new UserRepository(new SqlDbContext()).GetByName(model.Name) != null)
            {
                ModelState.AddModelError(nameof(model.Name), "*  用户名已存在");
                TempData[Keys.ErrorInModel] = ModelState;
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}