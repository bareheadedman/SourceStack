using BLL.Entities;
using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    class UserFactory
    {
        internal static User zhangsan;
        internal static User laowang;
        public static void Create()
        {
            zhangsan = register("张三");
            laowang = register("老王");


        }

        private static User register(string name)
        {
            const string pw = "1234";

            User user = new User() { Name = name, Password = pw };
            user.Regisert();
            UserRepository userRepository = new UserRepository(Helper.GetDbContext());
            userRepository.Save(user);
            return user;
        }



    }
}
