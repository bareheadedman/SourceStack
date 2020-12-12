using assignment.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using E = assignment.Entities;
namespace assignment.Repository

{
    public class UserRepository
    {
        private const string id = "Id";
        private const string userName = "UserName";
        private const string passWord = "PassWord";
        private const string profileId = "ProfileId";
        private const string inviter = "Inviter";
        private const string inviterCode = "InviterCode";
        private const string bMony = "BMony";
        private const string isMale = "IsMale";



        public User Find(int id)
        {
            DBHelp help = new DBHelp();
            User user = new User();
            user.InviterBy = new User();
            user.Articles = new List<Article>();
            using (IDbConnection connection = help.GetNewConnection())
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT {UserRepository.id},{userName},{passWord},{inviterCode},{inviter} FROM [User] WHERE Id = @id ";
                    DbParameter pId = new SqlParameter("@id", id);
                    command.Parameters.Add(pId);
                    IDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        if (reader.Read())
                        {
                            user.Name = reader[userName].ToString();
                            user.PassWord = reader[passWord].ToString();
                            user.InviterCode = reader[inviterCode].ToString();
                            user.Id = Convert.ToInt32(reader[UserRepository.id]);
                            user.InviterBy.Id = Convert.ToInt32(reader[inviter]);
                            user.Articles = new List<Article>();
                        }
                        else
                        {
                            user = null;
                        }
                    }

                }
            }

            return user;
        }
        public int Save(User user)
        {
            DBHelp help = new DBHelp();
            string cmdText = $"INSERT [User]({userName},{passWord},{inviter}) VALUES(@uName,@uPassWord,@uInviterById)SELECT @@IDENTITY;";
            IDataParameter[] parameters = new IDataParameter[3];
            parameters[0] = new SqlParameter("@uName", user.Name);
            parameters[1] = new SqlParameter("@uPassWord", user.PassWord);
            parameters[2] = new SqlParameter("@uInviterById", user.InviterBy.Id);
            return help.Inster(cmdText, parameters);
        }
        public User GetByName(string name)
        {
            DBHelp help = new DBHelp();
            User user = new User();
            user.InviterBy = new User();
            using (IDbConnection connection = help.GetNewConnection())
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT {UserRepository.id},{userName},{passWord},{inviter},{inviterCode} FROM [User] WHERE UserName = @name ;";
                    DbParameter pName = new SqlParameter("@name", name);
                    command.Parameters.Add(pName);
                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user.Name = reader[userName].ToString();
                        user.PassWord = reader[passWord].ToString();
                        user.Id = Convert.ToInt32(reader[id]);
                        user.InviterCode = reader[inviterCode].ToString();
                        user.InviterBy.Id = Convert.ToInt32(reader[inviter]);
                        user.Articles = new List<Article>();
                    }
                    else
                    {
                        user = null;
                    }

                }
            }

            return user;

        }
    }
}
