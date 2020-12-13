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
            string queryString = @"SELECT * FROM [TMessage]";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            DataSet yqBang = new DataSet();
            adapter.Fill(yqBang, "TMessage");

            yqBang.Tables[0].Rows[3]["Content"] = "马保国闪电鞭5连鞭";

            DataRow row = yqBang.Tables[0].NewRow();
            row["Content"] = "太极形意门掌门人";

            yqBang.Tables[0].Rows.Add(row);
            SqlCommand insertCmd = new SqlCommand("INSERT [TMessage]([Content]) VALUES(@content)", connection);
            IDbDataParameter pContent = new SqlParameter("@content", SqlDbType.NVarChar);
            pContent.SourceColumn = "Content";
            insertCmd.Parameters.Add(pContent);

            adapter.InsertCommand = insertCmd;

            SqlCommand updateCmd = new SqlCommand("UPDATE [TMessage] SET [Content]= @content Where Id = @id", connection);
            IDbDataParameter pName = new SqlParameter("@content", SqlDbType.NVarChar);
            pName.SourceColumn = "Content";
            IDbDataParameter pId = new SqlParameter("@id", SqlDbType.Int);
            pId.SourceColumn = "Id";

            updateCmd.Parameters.Add(pName);
            updateCmd.Parameters.Add(pId);

            adapter.UpdateCommand = updateCmd;

            adapter.Update(yqBang.Tables[0]);


            //object result = dtStudents.AsEnumerable().Where(s => s["Name"].ToString() == "刘伟1").SingleOrDefault()?["Id"];

        }
    }
}


