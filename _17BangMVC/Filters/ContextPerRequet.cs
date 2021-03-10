using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17BangMVC.Filters
{
    public class ContextPerRequet : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //保证业务逻辑错误也能回滚
            if (filterContext.Exception == null)
            {
                BaseService.CommintTransaction();
            }
            else
            {
                BaseService.RollbackTransaction();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}