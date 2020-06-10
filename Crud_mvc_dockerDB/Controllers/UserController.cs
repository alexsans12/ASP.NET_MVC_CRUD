using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Crud_mvc_dockerDB.Models;
using Crud_mvc_dockerDB.Models.Class;

namespace Crud_mvc_dockerDB.Controllers
{
    public class UserController : Controller
    {
        private bool veryfication;
        private UserDAO objUserDAO = new UserDAO();
        
        [HttpGet]
        public ActionResult All()
        {
            List<User> list = findAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User objUser)
        {
            objUserDAO.create(objUser);
            errorMessage(objUser);
            return View();
        }
        
        [HttpGet]
        public ActionResult Update(int id)
        {
            User objUser = new User();
            objUser.idUser = id;
            objUser = objUserDAO.find(objUser);
            
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Update(User objUser)
        {
            objUserDAO.update(objUser);
            return Redirect("~/User/All");
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            User objUser = new User();
            objUser.idUser = id;
            objUserDAO.delete(objUser);
            return Redirect("~/User/All");
        }
        
        public void create(User objUser)
        {
            //Validate name
            objUser.state = 99;
            string name = objUser.name;
            if (string.IsNullOrEmpty(name))
            {
                objUser.state = 10;
            }
            else
            {
                name = objUser.name.Trim();
                veryfication = name.Length > 0 && name.Length <= 50;
                if (!veryfication)
                {
                    objUser.state = 1;
                }
            }
            //Validate email
            string email = objUser.email;
            if (string.IsNullOrEmpty(email))
            {
                objUser.state = 20;
            }
            else
            {
                email = objUser.email.Trim();
                veryfication = email.Length > 0 && email.Length <= 255;
                if (!veryfication)
                {
                    objUser.state = 2;
                }
            }

            if (objUser.state == 99)
            {
                objUserDAO.create(objUser);
            }
        }
        
        public void update(User objUser)
        {
            //Validate name
            objUser.state = 99;
            string name = objUser.name;
            if (string.IsNullOrEmpty(name))
            {
                objUser.state = 10;
            }
            else
            {
                name = objUser.name.Trim();
                veryfication = name.Length > 0 && name.Length <= 50;
                if (!veryfication)
                {
                    objUser.state = 1;
                }
            }
            //Validate email
            string email = objUser.email;
            if (string.IsNullOrEmpty(email))
            {
                objUser.state = 20;
            }
            else
            {
                email = objUser.email.Trim();
                veryfication = email.Length > 0 && email.Length <= 255;
                if (!veryfication)
                {
                    objUser.state = 2;
                }
            }

            if (objUser.state == 99)
            {
                objUserDAO.update(objUser);
            }
        }

        public void delete(User objUser)
        {
            User objUserAux = new User();
            objUserAux.idUser = objUser.idUser;
            veryfication = Convert.ToBoolean(objUserDAO.find(objUserAux).state);
            if (!veryfication)
            {
                objUser.state = 30;
            }
            else
            {
                objUserDAO.delete(objUser);   
            }
        }

        public List<User> findAll()
        {
            return objUserDAO.findAll();
        }

        public void errorMessage(User objUser)
        {
            switch (objUser.state)
            {
                case 10:
                    ViewBag.errorMessage = "empty name field";
                    break;
                case 1:
                    ViewBag.errorMessage = "name isn't valid";
                    break;
                case 20:
                    ViewBag.errorMessage = "empty email field";
                    break;
                case 2:
                    ViewBag.errorMessage = "email isn't valid";
                    break;
                case 30:
                    ViewBag.errorMessage = "user not found";
                    break;
                default:
                    ViewBag.successMessage = "Registered user";
                    break;
            }
        }
    }
}