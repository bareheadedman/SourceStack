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

        public RegisterModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Regisert(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public int Save(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public IList<RegisterModel> Selected(string name)
        {
            throw new NotImplementedException();
        }
    }
}
