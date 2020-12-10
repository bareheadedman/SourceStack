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
    public class ArticleRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";

        public List<E.Article> Get(int pageIndex, int pageSize)
        {
            List<E.Article> articles = new List<Article>();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT Id FROM Article ORDER BY PublishDateTime OFFSET {(pageIndex - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            articles.Add(Find(Convert.ToInt32(reader["Id"])));
                        }
                    }


                }



            }

            return articles;


        }

        public E.Article Find(int id)
        {
            E.Article article = new Article();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM [Article] WHERE Id = '{id}'";
                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        article.Id = Convert.ToInt32(reader["Id"]);
                        article.Title = reader["Title"].ToString();
                        article.Body = reader["Content"].ToString();
                        article.PublishTime = (DateTime)reader["PublishDateTime"];
                        article.Author = new UserRepository().Find(Convert.ToInt32(reader["AuthorId"]));

                        article.keyWords = new KeyWordRepository().FindsArticle(id);

                    }
                    else
                    {
                        article = null;
                    }


                }
            }

            return article;
        }

        public int ArticlesCount()
        {
            int result = 0;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT count(*) FROM [Article] ";
                    result = Convert.ToInt32(command.ExecuteScalar());
                }


            }

            return result;
        }
    }
}
