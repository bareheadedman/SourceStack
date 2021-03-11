using AutoMapper;
using BLL.Entities;
using BLL.Repositories;
using GLB.Global;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SRV.ProdService
{
    public class BaseService
    {

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
        protected readonly static MapperConfiguration config;

        protected IMapper mapper
        {
            get { return config.CreateMapper(); }
        }

        private UserRepository UserRepository;

        //保证一个HTTP请求不会重复获取context
        protected SqlDbContext context
        {
            get
            {
                if (HttpContext.Current.Items[Keys.DBContext] == null)
                {
                    SqlDbContext sc = new SqlDbContext();
                    sc.Database.BeginTransaction();
                    HttpContext.Current.Items[Keys.DBContext] = sc;
                } // else nothing
                return (SqlDbContext)HttpContext.Current.Items[Keys.DBContext];
            }
        }


        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns>返回当前cookie用户,没有则返回NULL</returns>
        public User GetCurrentUser()
        {

            //拿到当前请求的cookie
            HttpCookie userInfo = HttpContext.Current.Request.Cookies.Get(Keys.User);
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

        /// <summary>
        /// 拿到当前Http请求的context !!!(仅用于提交或回滚,获取后会清除)
        /// </summary>
        /// <returns>当前Http请求的context</returns>
        private static SqlDbContext getContextFromHttp()
        {
            object objContext = HttpContext.Current.Items[Keys.DBContext];
            HttpContext.Current.Items.Remove(Keys.DBContext);
            return objContext as SqlDbContext;
        }

        /// <summary>
        /// 提交当前Http事务
        /// </summary>
        public static void CommintTransaction()
        {
            SqlDbContext context = getContextFromHttp();
            if (context != null)
            {
                using (context)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        transaction.Commit();
                    }
                }
            }//else nothing
        }

        /// <summary>
        /// 回滚当前Http事务
        /// </summary>
        public static void RollbackTransaction()
        {
            SqlDbContext context = getContextFromHttp();
            if (context != null)
            {
                using (context)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        transaction.Rollback();
                    }
                }
            }//else nothing
        }


    }
}
