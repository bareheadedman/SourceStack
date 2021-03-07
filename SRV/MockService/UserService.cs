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
        public RegisterModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
