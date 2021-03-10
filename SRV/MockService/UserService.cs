using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRV.MockService
{
    public class UserService : IUserService
    {
        public bool Exist(string name)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public UserModel GetCurrentUserAsModel()
        {
            throw new NotImplementedException();
        }

        public int Regisert(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public int Save(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public IList<UserModel> Selected(string name)
        {
            throw new NotImplementedException();
        }
    }
}
