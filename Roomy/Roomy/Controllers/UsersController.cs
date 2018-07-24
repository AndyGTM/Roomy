﻿using Roomy.Data;
using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;

namespace Roomy.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Civilities = db.Civilities.ToList(); 

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                user.Password = user.Password.HashMD5();

                // Enregistrer en BDD
                db.Users.Add(user);
                db.SaveChanges();
                // Redirection
                TempData["Message"] = $"Utilisateur {user.Firstname} enregistré.";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Civilities = db.Civilities.ToList();
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}