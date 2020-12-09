using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using E = assignment.Entities;
namespace assignment.Repository

{
    public class KeyWordRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";


        public static List<E.KeyWord> KeyWords { get; set; }

        static KeyWordRepository()
        {
            KeyWords = new List<E.KeyWord>();
        }

        public E.KeyWord Find(int id)
        {
            E.KeyWord keyWord = new E.KeyWord();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM [keyword] WHERE Id ={id}";
                    IDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        keyWord.Id = Convert.ToInt32(reader["Id"]);
                        keyWord.Content = reader["Word"].ToString();

                    }
                    else
                    {
                        keyWord = null;
                    }

                }
            }


            return keyWord;
        }

        public List<E.KeyWord> FindsArticle(int id)
        {
            List<E.KeyWord> keyWords = new List<E.KeyWord>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM [Keyword2Article] WHERE Id= '{id}'";
                    IDataReader reader = command.ExecuteReader();

                    List<int> result = new List<int>();
                    if (reader.Read())
                    {
                        result.Add(Convert.ToInt32(reader["KeywordId"]));
                    }
                    else
                    {
                        keyWords = null;
                    }

                    foreach (var item in result)
                    {
                        keyWords.Add(Find(item));

                    }


                }
            }

            return keyWords;
        }
    }
}
