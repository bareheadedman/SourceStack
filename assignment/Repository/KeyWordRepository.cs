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
        private const string id = "Id";
        private const string word = "Word";
        private const string keyWordId = "KeywordId";
        private const string articleId = "ArticleId";


        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";

        public E.KeyWord Find(int id)
        {
            E.KeyWord keyWord = new E.KeyWord();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT {KeyWordRepository.id},{word} FROM [keyword] WHERE Id ={id}";
                    IDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        keyWord.Id = Convert.ToInt32(reader[KeyWordRepository.id]);
                        keyWord.Content = reader[word].ToString();

                    }
                    else
                    {
                        keyWord = null;
                    }

                }
            }


            return keyWord;
        }

        public List<E.KeyWord> FindsArticle(int articleid)
        {
            List<E.KeyWord> keyWords = new List<E.KeyWord>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT {keyWordId} FROM [Keyword2Article] WHERE Id= '{articleid}'";
                    IDataReader reader = command.ExecuteReader();

                    List<int> result = new List<int>();
                    if (reader.Read())
                    {
                        result.Add(Convert.ToInt32(reader[keyWordId]));
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
