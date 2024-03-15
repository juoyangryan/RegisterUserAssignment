﻿using RegisterUserAssignment.DAL;
using RegisterUserAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterUserAssignment.Controllers
{
    public class RegistrationController : Controller
    {
        UserDAL userDAL = new UserDAL();

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            List<User> users = userDAL.GetUsers();
            return View(users);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {

                userDAL.AddUser(user);
                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToAction("AllUsers");
            }
            return View("Index");
        }
    }
}