using AutoMapper;
using BLL.Entities;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class BaseService
    {
        protected readonly static MapperConfiguration config;

        //在实例构造函数,配置AutoMapper,节省性能
        static BaseService()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, RegisterModel>()
                        .ForMember(dest => dest.InvitedCode, opt => opt.MapFrom(src => src.InviteCode))
                        .ReverseMap();

                });
        }
        protected IMapper mapper
        {
            get { return config.CreateMapper(); }
        }
    }
}
