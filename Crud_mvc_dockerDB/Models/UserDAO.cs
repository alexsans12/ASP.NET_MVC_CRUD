using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Crud_mvc_dockerDB.Models.Class;

namespace Crud_mvc_dockerDB.Models
{
    public class UserDAO : Required<User>
    {
        private Connection objConnection;
        private OracleCommand cmd;

        public UserDAO()
        {
            objConnection = Connection.connectionState();
        }

        public void create(User objUser)
        {
            string create = "INSERT INTO users(name,email) VALUES('" + objUser.name + "', '" + objUser.email + "')";
            try
            {
                cmd = new OracleCommand(create, objConnection.GetConnection());
                objConnection.GetConnection().Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
            }
            finally
            {
                objConnection.GetConnection().Close();
                objConnection.closeConnection();
            }
        }

        public void update(User objUser)
        {
            string update = "UPDATE users SET name = '" + objUser.name + "', email = '" + objUser.email + "' WHERE id = '" + objUser.idUser + "'";
            try
            {
                cmd = new OracleCommand(update, objConnection.GetConnection());
                objConnection.GetConnection().Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
            }
            finally
            {
                objConnection.GetConnection().Close();
                objConnection.closeConnection();
            }
        }

        public void delete(User objUser)
        {
            string delete = "DELETE FROM users WHERE id = '" + objUser.idUser + "'";
            try
            {
                cmd = new OracleCommand(delete, objConnection.GetConnection());
                objConnection.GetConnection().Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
            }
            finally
            {
                objConnection.GetConnection().Close();
                objConnection.closeConnection();
            }
        }

        public User find(User objUser)
        {
            bool findUser = false;
            string find = "SELECT * FROM users WHERE id = '" + objUser.idUser + "'";

            try
            {
                cmd = new OracleCommand(find, objConnection.GetConnection());
                objConnection.GetConnection().Open();
                OracleDataReader read = cmd.ExecuteReader();
                findUser = read.Read();

                if (findUser)
                {
                    objUser.idUser = Convert.ToInt32(read[0].ToString());
                    objUser.name = read[1].ToString();
                    objUser.email = read[2].ToString();
                    objUser.state = 99;
                }
                else
                {
                    objUser.state = 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
            }
            finally
            {
                objConnection.GetConnection().Close();
                objConnection.closeConnection();
            }
            
            return objUser;
        }

        public List<User> findAll()
        {
            List<User> listUsers = new List<User>();
            string findAll = "SELECT * FROM users";

            try
            {
                cmd = new OracleCommand(findAll, objConnection.GetConnection());
                objConnection.GetConnection().Open();
                OracleDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    User objUser = new User();
                    objUser.idUser = Convert.ToInt32(read[0].ToString());
                    objUser.name = read[1].ToString();
                    objUser.email = read[2].ToString();
                    listUsers.Add(objUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage findAll ---\n{0}", ex.Message);
                Console.WriteLine("\nHelpLink findAll ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource findAll ---\n{0}", ex.Source);
            }
            finally
            {
                objConnection.GetConnection().Close();
                objConnection.closeConnection();
            }

            return listUsers;
        }
        
    }
}