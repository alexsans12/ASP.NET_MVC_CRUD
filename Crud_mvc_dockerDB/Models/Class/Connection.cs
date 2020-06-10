using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Crud_mvc_dockerDB.Models
{
    public class Connection
    {
        //singlenton
        private static Connection objConnection = null;
        private SqlConnection conn;

        private Connection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        }

        public static Connection connectionState()
        {
            if (objConnection == null)
            {
                objConnection = new Connection();
            }

            return objConnection;
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public void closeConnection()
        {
            objConnection = null;
        }
    }
}