using _17BangMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using BLL.Repositories;

namespace _17BangMVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            if (TempData["ModelError"] != null)
            {
                ModelState.Merge(TempData["ModelError"] as ModelStateDictionary);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModels model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ModelError"] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(model.ConfirmPassword, "* 确认密码和密码不一致");
                TempData["ModelError"] = ModelState;
                return RedirectToAction(nameof(Index));

            }
            User invitedby = new UserRepository(new SqlDbContext()).GetByName(model.InvitedName);
            if (invitedby == null)
            {
                ModelState.AddModelError(model.InvitedName, "* 邀请人不存在");
                TempData["ModelError"] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (invitedby.InviteCode != model.InvitedCode)
            {
                ModelState.AddModelError(model.InvitedCode, "* 邀请码不正确");
                TempData["ModelError"] = ModelState;
                return RedirectToAction(nameof(Index));
            }
            if (new UserRepository(new SqlDbContext()).GetByName(model.Name) != null)
            {
                ModelState.AddModelError(model.Name, "*  用户名已存在");
                TempData["ModelError"] = ModelState;
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}