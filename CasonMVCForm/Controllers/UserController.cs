using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CasonMVCForm.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CasonMVCForm.Controllers
{
    public class UserController : Controller
    {
        public static List<User> list = new List<User>();
        bool dataValid;
        bool emailIsValid;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            emailIsValid = new EmailAddressAttribute().IsValid(user.Email);
            dataValid = isDataValid(user);
            if ( list.Count == 0 && dataValid && emailIsValid && user.Email.Length < 100)
            {
                list.Add(user);
                ViewData["Message"] = "User " + user.Name + " successfully created";
            }
            else {
                if (!list.Any(x => x.Name.Equals(user.Name)) && user.Name.Length < 64
                    && !list.Any(x => x.Email.Equals(user.Email)) && emailIsValid && user.Email.Length < 100)
                {
                    list.Add(user);
                    ViewData["Message"] = "User " + user.Name + " successfully created";
                }
                else
                {
                    if (list.Any(x => x.Name.Equals(user.Name)))
                    {
                        ViewData["Message"] = "User " + user.Name + " already exists";
                    }
                    if (user.Name.Length >= 64)
                    {
                        ViewData["Message"] = "Username too long. Maximum size: 64";
                    }
                    if (list.Any(x => x.Email.Equals(user.Email)))
                    {
                        ViewData["Message"] = "User with " + user.Email + " email address already exists";
                    }
                    if (!emailIsValid)
                    {
                        ViewData["Message"] = "Email " + user.Email + " is not in the correct format";
                    }
                    if (user.Email.Length >= 100)
                    {
                        ViewData["Message"] = "Email address too long: Maximum size: 100";
                    }
                }
            }

            ViewBag.Users = list;
            return View(user);
        }
        
        public bool isDataValid(User user)
        {
            if (user.Name.Length >= 64)
            {
                ViewData["Message"] = "Username too long. Maximum size: 64";
                return false;
            }
            else if (user.Email.Length >= 100)
            {
                ViewData["Message"] = "Email address too long: Maximum size: 100";
                return false;
            }
            else if (!emailIsValid)
            {
                ViewData["Message"] = "Email " + user.Email + " is not in the correct format";
                return false;
            }
            else return true;
        }
    }
}