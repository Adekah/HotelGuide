using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelGuide.Business;
using Microsoft.AspNetCore.Mvc;
using HotelGuide.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Session;

namespace HotelGuide.WebUI.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index(string searchString)
        {
            HotelBusiness business = new HotelBusiness();

            ViewBag.AllHotels = business.GetHotels();

            if (string.IsNullOrEmpty(searchString))
            {
                return View();
            }
            else
            {
                ViewBag.SearchedHotels = business.GetHotelSearchResult(searchString);

            }

            return View();

        }

        public IActionResult HotelDetail()
        {
            HotelBusiness business = new HotelBusiness();
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var hotelDetail = business.GetHotelDetail(id);
            ViewBag.HotelContact = business.GetHotelContact(id);
            ViewBag.HotelComment = business.GetHotelComment(id);
            return View(hotelDetail);
        }

    



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
