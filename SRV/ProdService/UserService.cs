using BLL.Repositories;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace SRV.ProdService
{
    public class UserService:BaseService,IUserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            SqlDbContext dbContext = new SqlDbContext();
            userRepository = new UserRepository(dbContext);
        }

        /// <summary>
        ///  通过name找到实体entity返回model
        ///  </summary>
        /// <param name="invitedName">
        /// user的Name
        /// </param>
        /// <returns></returns>
        public RegisterModel GetByName(string name)
        {
            User user= userRepository.GetByName(name);
            return mapper.Map<RegisterModel>(user);
        }

        public void Save(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
