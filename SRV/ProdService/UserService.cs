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
    public class UserService : BaseService, IUserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            SqlDbContext dbContext = new SqlDbContext();
            userRepository = new UserRepository(dbContext);
        }

        public bool Exist(string name)
        {

            if (userRepository.GetByName(name) == null)
            {
                return false;
            }
            else
            {
                return true;

            }

        }

        public RegisterModel GetByName(string name)
        {
            User user = userRepository.GetByName(name);
            return mapper.Map<RegisterModel>(user);
        }

        public void Regisert(RegisterModel model)
        {
            User user = mapper.Map<User>(model);
            user.Regisert();
            userRepository.Save(user);
        }

        public int Save(RegisterModel model)
        {
            User user = mapper.Map<User>(model);
            return userRepository.Save(user);
        }

        public IList<RegisterModel> Selected(string name)
        {

            IList<User> users = userRepository.Selected(name);
            if (users == null)
            {
                return null;
            } // else nothing
            return mapper.Map<IList<User>, IList<RegisterModel>>(users);
        }
    }
}
