using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Crud_mvc_dockerDB.Models;
using Crud_mvc_dockerDB.Models.Class;

namespace Crud_mvc_dockerDB.Controllers
{
    public class UserController : Controller
    {
        public List<string> listErrors;
        public bool veryfication;
        private UserDAO objUserDAO = new UserDAO();
        public ActionResult AllUsers()
        {
            List<User> list = findAll();
            return View(list);
        }

        public void create(User objUser)
        {
            //Validate name
            string name = objUser.name;
            if (name == null)
            {
                listErrors.Add("name isn't valid");
            }
            else
            {
                name = objUser.name.Trim();
                veryfication = name.Length > 0 && name.Length <= 50;
                if (!veryfication)
                {
                    listErrors.Add("name isn't valid");
                }
            }
            //Validate email
            string emailFormat = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(objUser.email, emailFormat)) 
            {
                if (Regex.Replace(objUser.email, emailFormat, string.Empty).Length != 0) 
                { 
                    listErrors.Add("email");
                }
            } 
            else
            { 
                listErrors.Add("email");
            }
            
            objUserDAO.create(objUser);
        }

        public void delete(User objUser)
        {
            User objUserAux = new User();
            objUserAux.idUser = objUser.idUser;
            veryfication = objUserDAO.find(objUserAux);
            if (!veryfication)
            {
                listErrors.Add("User not found");
            }
            objUserDAO.delete(objUser);
        }

        public List<User> findAll()
        {
            return objUserDAO.findAll();
        }
    }
}