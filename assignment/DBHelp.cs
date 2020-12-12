using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace assignment
{
    public class DBHelp
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17BANG;Integrated Security=True;";

        public IDbConnection GetNewConnection()
        {
            return new SqlConnection(connectionString);
        }


        private int executeNonQuery(string cmdText, params IDataParameter[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.CommandText = cmdText;
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            return executeNonQuery(command);

        }
        private int executeNonQuery(IDbCommand cmd)
        {
            using (IDbConnection connection = GetNewConnection())
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = transaction;
                        int result = cmd.ExecuteNonQuery();
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
        private object executeScalar(IDbCommand cmd)
        {
            using (IDbConnection connection = GetNewConnection())
            {
                connection.Open();
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = transaction;
                        object result = cmd.ExecuteScalar();
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
        private object executeScalar(string cmdText, params IDataParameter[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.CommandText = cmdText;
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            return executeScalar(command);
        }
        private int batchExecute(string cmdText, params IDataParameter[] parameters)
        {
            int result = 0;
            using (IDbConnection connection = GetNewConnection())
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

        public object SelectScalar(string cmdText)
        {
            IDbCommand command = new SqlCommand();
            command.CommandText = cmdText;
            return executeScalar(command);
        }
        public object SelectScalar(string cmdText, params IDataParameter[] parameters)
        {
            IDbCommand command = new SqlCommand();
            command.CommandText = cmdText;
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            return executeScalar(command);
        }
        public int Inster(string cmdText, params IDataParameter[] parameters)
        {
            return Convert.ToInt32(executeScalar(cmdText, parameters));
        }
        public int Update(string cmdText, params IDataParameter[] parameters)
        {
            return executeNonQuery(cmdText, parameters);
        }
        public int Delete(string cmdText, params IDataParameter[] parameters)
        {
            return executeNonQuery(cmdText, parameters);
        }
        public int UpdateRange(string cmdText, params IDataParameter[] parameters)
        {
            return batchExecute(cmdText, parameters);
        }
        public int DeleteRange(string cmdText, params IDataParameter[] parameters)
        {
            return batchExecute(cmdText, parameters);
        }

    }

}


