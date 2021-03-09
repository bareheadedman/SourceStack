using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ServiceInterface;
using SRV.ViewModel;

namespace _17BangMVC.Controllers
{
    public class SelectedUserController : Controller
    {
        private IUserService userService;
        public SelectedUserController()
        {
            userService = new SRV.ProdService.UserService();
            //userService = new SRV.MockService.UserService();
        }

        public ActionResult Index()
        {
            SelectedUserModel model = new SelectedUserModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Index(SelectedUserModel model)
        {

            model.SelectedUsers = userService.Selected(model.Name);

            return PartialView(model);
        }
    }
}