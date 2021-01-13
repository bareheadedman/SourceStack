using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Filters
{
    public class ModelErrorTransferFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            ModelStateDictionary modelState = ((Controller)filterContext.Controller).ModelState;

            if (filterContext.HttpContext.Request.HttpMethod == Keys.Post)
            {
                if (!modelState.IsValid)
                {
                    filterContext.Controller.ViewData[Keys.ErrorInModel] = modelState;
                    filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.PathAndQuery);
                }

            }
            else if (filterContext.HttpContext.Request.HttpMethod == Keys.Get)
            {
                ModelStateDictionary errors = filterContext.Controller.TempData[Keys.ErrorInModel] as ModelStateDictionary;
                if (errors != null)
                {
                    modelState.Merge(errors);
                } //else nothin
            }
            else
            {
                throw new NotImplementedException("未实现的请求方式");
            }



            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }


    }
}