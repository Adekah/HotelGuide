using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelGuide.Business;
using HotelGuide.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using HotelGuide.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Session;

namespace HotelGuide.WebUI.Controllers
{
    public class HotelController : Controller
    {
        [HttpPost]
        public IActionResult HotelComment(string hotelComment, int hotelCommentScore, int hotelId)
        {

            int? userID = HttpContext.Session.GetInt32("UserId");
            HotelComment hotelcomment = new HotelComment();

            hotelcomment.HotelId = hotelId;
            hotelcomment.UserId = userID;
            hotelcomment.Comment = hotelComment;
            hotelcomment.Score = hotelCommentScore;
            HotelBusiness business = new HotelBusiness();
            business.AddHotelComment(hotelcomment);
            return RedirectToAction("Index", "Hotel");
        }

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
            int hotelId = Convert.ToInt32(RouteData.Values["id"]);
            var hotelDetail = business.GetHotelDetail(hotelId);
            ViewBag.HotelContact = business.GetHotelContact(hotelId);
            ViewBag.HotelComment = business.GetHotelComment(hotelId);
            return View(hotelDetail);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
