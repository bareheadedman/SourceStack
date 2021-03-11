using BLL.Repositories;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using GLB.Global;

namespace SRV.ProdService
{
    public class UserService : BaseService, IUserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository(context);
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

        public UserModel GetByName(string name)
        {
            User user = userRepository.GetByName(name);
            return mapper.Map<UserModel>(user);
        }

        public int Regisert(RegisterModel model)
        {
            User user = mapper.Map<User>(model);
            user.Regisert();
            return userRepository.Save(user);
        }

        public int Save(RegisterModel model)
        {
            User user = mapper.Map<User>(model);
            return userRepository.Save(user);
        }

        public IList<UserModel> Selected(string name)
        {

            IList<User> users = userRepository.Selected(name);
            if (users == null)
            {
                return null;
            } // else nothing
            return mapper.Map<IList<User>, IList<UserModel>>(users);
        }

        public UserModel GetCurrentUserAsModel()
        {
            User current = GetCurrentUser();
            return mapper.Map<UserModel>(current);

        }
    }
}
