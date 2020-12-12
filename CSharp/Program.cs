using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Schema;


namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {


            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";
            string cmdText = "SELECT [Id],[Content] FROM [TMessage] WHERE Id = @id";
            IDataParameter parameter = new SqlParameter("@id", 5);


            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDataReader reader = ExecuteReader(cmdText, connection, parameter);

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Id"]);
                    string content = reader["Content"].ToString();
                }
                else
                {

                }

            }



            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (IDbTransaction transaction = connection.BeginTransaction())
            //    {

            //        try
            //        {
            //            using (IDbCommand command = new SqlCommand())
            //            {
            //                command.Connection = connection;
            //                command.Transaction = transaction;
            //                command.CommandText = "INSERT [User] ([UserName],[PassWord]) VALUES('lg','85277') ";
            //                command.ExecuteNonQuery();
            //                transaction.Commit();

            //            }
            //        }
            //        catch (Exception)
            //        {
            //            transaction.Rollback();
            //            throw;
            //        }
            //    }


            //}
        }
        private static int batchExecute(string cmdText, params IDataParameter[] parameters)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";
            int result = 0;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        IDbCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = cmdText;
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.Add(parameters[i]);
                            result += command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static IDataReader ExecuteReader(string cmdText, IDbConnection connection, params IDataParameter[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.CommandText = cmdText;
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            return executeReader(command, connection);
        }

        private static IDataReader executeReader(IDbCommand cmd, IDbConnection connection)
        {
            connection.Open();
            cmd.Connection = connection;
            return cmd.ExecuteReader();



        }


    }
}


