using CSharp._17bangTableAdapters;
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
using static CSharp._17bang;

namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            _17bang bang = new _17bang();
            //TMessageRow row = bang.TMessage.FindById(1);

            //Console.WriteLine(row.Id + row.Content);
            //row.Content = "他很快啊";
            //Console.WriteLine(row.Id + row.Content);


            //TMessageRow message = bang.TMessage.NewTMessageRow();
            //message.Content = "气功大师马保国";

            TMessageTableAdapter adapter = new TMessageTableAdapter();
            TMessageDataTable TMessage = adapter.GetData();


            //TMessage.Where(t =>t.IsContentNull() ).SingleOrDefault().Delete()
            TMessageRow row = TMessage.NewTMessageRow();
            row.Content = "气功大师马保国";
            row.HasRead = false;
            //adapter.Insert("大师马保国",1005,false);
            TMessage.AddTMessageRow(row);


            adapter.Update(TMessage);







            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";
            //string queryString = @"SELECT * FROM [TMessage]";

            //SqlConnection connection = new SqlConnection(connectionString);
            //SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            //DataSet yqBang = new DataSet();
            //adapter.Fill(yqBang, "TMessage");

            //yqBang.Tables[0].Rows[3]["Content"] = "马保国闪电鞭5连鞭";

            //DataRow row = yqBang.Tables[0].NewRow();
            //row["Content"] = "太极形意门掌门人";

            //yqBang.Tables[0].Rows.Add(row);
            //SqlCommand insertCmd = new SqlCommand("INSERT [TMessage]([Content]) VALUES(@content)", connection);
            //IDbDataParameter pContent = new SqlParameter("@content", SqlDbType.NVarChar);
            //pContent.SourceColumn = "Content";
            //insertCmd.Parameters.Add(pContent);

            //adapter.InsertCommand = insertCmd;

            //SqlCommand updateCmd = new SqlCommand("UPDATE [TMessage] SET [Content]= @content Where Id = @id", connection);
            //IDbDataParameter pName = new SqlParameter("@content", SqlDbType.NVarChar);
            //pName.SourceColumn = "Content";
            //IDbDataParameter pId = new SqlParameter("@id", SqlDbType.Int);
            //pId.SourceColumn = "Id";

            //updateCmd.Parameters.Add(pName);
            //updateCmd.Parameters.Add(pId);

            //adapter.UpdateCommand = updateCmd;

            //adapter.Update(yqBang.Tables[0]);


            //object result = dtStudents.AsEnumerable().Where(s => s["Name"].ToString() == "刘伟1").SingleOrDefault()?["Id"];

        }
    }
}


