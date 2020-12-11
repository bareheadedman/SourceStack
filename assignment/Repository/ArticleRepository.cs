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
    public class ArticleRepository
    {
        private const string id = "Id";
        private const string title = "Title";
        private const string content = "Content";
        private const string authorId = "AuthorId";
        private const string publishDateTime = "PublishDateTime";
        private const string category = "Category";

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
                    command.CommandText = $"SELECT Id FROM Article ORDER BY PublishDateTime OFFSET @index ROWS FETCH NEXT @size ROWS ONLY";
                    DbParameter pPageIndex = new SqlParameter("@index", (pageIndex - 1) * pageSize);
                    DbParameter pPageSize = new SqlParameter("@size", pageSize);

                    command.Parameters.Add(pPageIndex);
                    command.Parameters.Add(pPageSize);

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            articles.Add(Find(Convert.ToInt32(reader[ArticleRepository.id])));
                        }
                    }


                }



            }

            return articles;


        }

        public List<Article> FindAuthorId(int id)
        {
            List<Article> articles = new List<Article>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $" SELECT {ArticleRepository.id} FROM Article WHERE {authorId}= @id ";

                    DbParameter pId = new SqlParameter("@id", id);
                    command.Parameters.Add(pId);

                    IDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        articles.Add(Find(Convert.ToInt32(reader[ArticleRepository.id])));
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
                    command.CommandText = $"SELECT {ArticleRepository.id},{title},{content},{authorId},{publishDateTime},{category} FROM [Article] WHERE Id = @id";

                    DbParameter pId = new SqlParameter("@id", id);
                    command.Parameters.Add(pId);

                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        article.Id = Convert.ToInt32(reader[ArticleRepository.id]);
                        article.Title = reader[title].ToString();
                        article.Body = reader[content].ToString();
                        article.PublishTime = (DateTime)reader[publishDateTime];
                        article.Author = new User() { Id = Convert.ToInt32(reader[authorId]) };

                        article.keyWords = new List<KeyWord>();

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
