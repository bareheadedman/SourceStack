using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ServiceInterface;
using SRV.ViewModel;

namespace _17BangMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController()
        {
            userService = new SRV.ProdService.UserService();
            //userService = new SRV.MockService.UserService();
        }

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="Name">需要检查的string</param>
        /// <returns>返回为true表示验证通过，false表示验证失败</returns>
        [HttpGet]
        public JsonResult UserIsExist(String Name)
        {
            bool Exist = userService.Exist(Name);
            return Json(!Exist,JsonRequestBehavior.AllowGet);

        }
    }
}