using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuide.WebUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Index", "Hotel");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Business.UserBusiness.Login(username, password);


            if (user != null)
            {
                HttpContext.Session.SetInt32("UserID", user.Id);
                TempData["user"] = user.UserName;
                return RedirectToAction("Index", "Hotel");
            }
            else
            {
                ViewBag.errormessage = "Kullanıcı Adı ya da Şifre Hatalı.";
                return View();
            }

        }
    }
}