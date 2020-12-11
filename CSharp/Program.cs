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
            string user = Console.ReadLine().ToString();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT Inviter FROM[User] Where UserName ='@name'";
                    DbParameter pname = new SqlParameter("@name", user);
                    command.Parameters.Add(pname);

                    object count = command.ExecuteScalar();

                    if (count == DBNull.Value)
                    {

                    }



                    //IDataReader reader = command.ExecuteReader();

                    // while (reader.Read())
                    // {
                    //     for (int i = 0; i < reader.FieldCount; i++)
                    //     {
                    //         Console.Write(reader[i]+",");
                    //     }
                    //     Console.WriteLine();
                    // }




                    //Object count = command.ExecuteScalar();
                    //Console.WriteLine(count);



                    //command.CommandText = @"INSERT [User]([UserName],[PassWord]) VALUES('mabaoguo','1234');";
                    //int rowsAffected = command.ExecuteNonQuery();
                    //Console.WriteLine(rowsAffected);
                }


            }






        }
    }


}

