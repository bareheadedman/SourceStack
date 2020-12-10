using assignment.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using E = assignment.Entities;
namespace assignment.Repository

{
    public class UserRepository
    {

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
                    command.CommandText = $"SELECT * FROM [User] WHERE Id = {id}";
                    IDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        if (reader.Read())
                        {
                            user.Name = reader["UserName"].ToString();
                            user.PassWord = reader["PassWord"].ToString();
                            user.Id = Convert.ToInt32(reader["Id"]);
                            user.InviterBy.Id = Convert.ToInt32(reader["Inviter"]);
                        }
                        else
                        {
                            user = null;
                        }
                    }


                    command.CommandText = $"SELECT [Id] FROM Article WHERE AuthorId = '{user.Id}' ";

                    IDataReader articleIds = command.ExecuteReader();

                    while (articleIds.Read())
                    {
                        user.Articles.Add(new Article { Id = Convert.ToInt32(articleIds["Id"]) });
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
                    command.CommandText = $"INSERT [User]([UserName],[PassWord],[Inviter]) VALUES('{user.Name}','{user.PassWord}',{user.InviterBy.Id});";
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
                    command.CommandText = $"SELECT * FROM [User] WHERE UserName ='{name}';";
                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user.Name = reader["UserName"].ToString();
                        user.PassWord = reader["PassWord"].ToString();
                        user.Id = Convert.ToInt32(reader["Id"]);
                        user.InviterBy.Id = Convert.ToInt32(reader["Inviter"]);
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
