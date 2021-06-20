using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccreditationApp
{
    class DBAccess
    {
        private static SqlConnection connection = new SqlConnection();
        private static SqlCommand command = new SqlCommand();
        private static SqlDataReader DbReader;
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        public SqlTransaction DbTran;

        public static string strConnString = "Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True";

        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void closeConn()
        {
            connection.Close();
        }

        public int executeDataAdapter(DataTable tblName, string strSelectSql)
        {
            try {
                if (connection.State == 0)
                {
                    createConn();
                }
      
                adapter.SelectCommand.CommandText = strSelectSql;
                adapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(adapter);

                string insert = DbCommandBuilder.GetInsertCommand().CommandText.ToString();
                string update = DbCommandBuilder.GetUpdateCommand().CommandText.ToString();
                string delete = DbCommandBuilder.GetDeleteCommand().CommandText.ToString();

                return adapter.Update(tblName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void readDatathroughAdapter(string query, DataTable tblName)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                adapter = new SqlDataAdapter(command);
                adapter.Fill(tblName);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlDataReader readDatathroughReader(string query)
        {
            SqlDataReader reader;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                reader = command.ExecuteReader();
                return reader;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public int executeQuery(SqlCommand dbCommand)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }
                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;

                return dbCommand.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
