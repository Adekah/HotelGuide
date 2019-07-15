using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HotelGuide.Business;
using Microsoft.AspNetCore.Mvc;
using HotelGuide.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Session;

namespace HotelGuide.WebUI.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View();
            }

           return RedirectToAction("Index", "Hotel");

        }


        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = Business.UserBusiness.Login(userName, password);


            if (String.IsNullOrEmpty(user.UserName))
            {
                ViewBag.errormessage = "Kullanıcı Adı ya da Şifre Hatalı.";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.UserName);

                return RedirectToAction("Index", "Hotel");

            }
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index","Hotel");

        }

    }
}