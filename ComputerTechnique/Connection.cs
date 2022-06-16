using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ComputerTechnique
{
    class Connection
    {
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=26.219.147.64,20123;Initial Catalog=ComputerTechnique;Persist Security Info=True;User ID=admin;Password=37Atagug");

        public static bool connectOpen()
        {
            bool temp = false;
            try
            {
                sqlConnection.Open();
                temp = true;
            }
            catch
            {
                temp = false;
            }
            return temp;
        }

        public static void connectClose()
        {
            try
            {
                sqlConnection.Close();
            }
            catch { }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
