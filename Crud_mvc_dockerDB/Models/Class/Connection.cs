using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Crud_mvc_dockerDB.Models.Class
{
    public class Connection
    {
        //singlenton
        private static Connection objConnection = null;
        private OracleConnection conn;

        private Connection()
        {
            string connectionString = "User Id=admin;Password=admin;Data Source=localhost:1521/XE;";
            conn = new OracleConnection();
            conn.ConnectionString = connectionString;
        }

        public static Connection connectionState()
        {
            if (objConnection == null)
            {
                objConnection = new Connection();
            }

            return objConnection;
        }

        public OracleConnection GetConnection()
        {
            return conn;
        }

        public void closeConnection()
        {
            objConnection = null;
        }
    }
}