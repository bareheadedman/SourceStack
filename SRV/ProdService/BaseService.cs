using AutoMapper;
using BLL.Entities;
using BLL.Repositories;
using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SRV.ProdService
{
    public class BaseService
    {
        protected readonly static MapperConfiguration config;

        protected IMapper mapper
        {
            get { return config.CreateMapper(); }
        }

        //保证ContextPerRequest
        protected SqlDbContext context
        {
            get
            {
                if (HttpContext.Current.Items[Keys.DBContext] == null)
                {
                    HttpContext.Current.Items[Keys.DBContext] = new SqlDbContext();
                }
                return (SqlDbContext)HttpContext.Current.Items[Keys.DBContext];
            }
        }

        private UserRepository UserRepository;

        public BaseService()
        {
            UserRepository = new UserRepository(context);
        }
        //在构造函数配置AutoMapper,节省性能
        static BaseService()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserModel>()
                       .ForMember(dest => dest.InvitedCode, opt => opt.MapFrom(src => src.InviteCode))
                       .ReverseMap();
                    cfg.CreateMap<User, RegisterModel>()
                       //配置指定的两个属性进行映射
                       .ForMember(dest => dest.InvitedCode, opt => opt.MapFrom(src => src.InviteCode))
                       .ReverseMap();

                });
        }


        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns>返回当前cookie用户,没有则返回NULL</returns>
        public User GetCurrentUser()
        {
            //拿到当前请求的cookie
            NameValueCollection userInfo = HttpContext.Current.Request.Cookies[Keys.User].Values;
            if (userInfo == null)
            {
                return null;
            }
            //拿到cookie的Id
            bool hasUserId = int.TryParse(userInfo[Keys.Id], out int current);
            if (!hasUserId)
            {
                HttpCookie restCookie = new HttpCookie(Keys.User);
                restCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(restCookie);
                return null;
            }
            //拿到cookie的密码
            string pswInCookie = userInfo[Keys.Password];
            if (string.IsNullOrWhiteSpace(pswInCookie))
            {
                HttpCookie restCookie = new HttpCookie(Keys.User);
                restCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(restCookie);
                return null;
            }
            //拿到当前用户的信息
            User userInRepository = UserRepository.GetById(current);
            if (userInRepository.Password != pswInCookie)
            {
                HttpCookie restCookie = new HttpCookie(Keys.User);
                restCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(restCookie);
                return null;
            }
            return userInRepository;
        }




    }
}
