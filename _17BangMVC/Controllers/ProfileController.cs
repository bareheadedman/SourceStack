using _17BangMVC.Filters;
using SRV.ServiceInterface;
using SRV.ViewModel;
using SRV.ViewModel.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Controllers
{
    [ModelErrorTransferFilter]
    public class ProfileController : Controller
    {
        private IUserService userService;
        private IKeywordService keywordService;

        public ProfileController(IUserService userService, IKeywordService keywordService)
        {
            this.userService = userService;
            this.keywordService = keywordService;
        }


        public ActionResult Write()
        {
            UserModel user = userService.GetCurrentUserAsModel();
            if (user == null || user.keywords.Count == 0)
            {
                return View(new WriteModel() { IsMale = true });
            }
            WriteModel writeModel = new WriteModel();
            writeModel.keywords = user.keywords;
            writeModel.IsMale = true;
            return View(writeModel);
        }

        [HttpPost]
        public ActionResult Write(WriteModel model)
        {
            return View();
        }











    }
}