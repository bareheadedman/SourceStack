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


        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";

        public User Find(int id)
        {
            User user = new User();
            user.InviterBy = new User();
            user.Articles = new List<Article>();
            using (IDbConnection connection = new SqlConnection(connectionString))
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
        public void Save(User user)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"INSERT [User]({userName},{passWord},{inviter}) VALUES(@uName,@uPassWord,@uInviterById);";
                    DbParameter pUName = new SqlParameter("@uName", user.Name);
                    DbParameter pUPassWord = new SqlParameter("@uPassWord", user.PassWord);
                    DbParameter pUInviterById = new SqlParameter("@uInviterById", user.InviterBy.Id);
                    command.Parameters.Add(pUName);
                    command.Parameters.Add(pUPassWord);
                    command.Parameters.Add(pUInviterById);

                    command.ExecuteNonQuery();
                }
            }
        }
        public User GetByName(string name)
        {
            User user = new User();
            user.InviterBy = new User();
            using (IDbConnection connection = new SqlConnection(connectionString))
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
