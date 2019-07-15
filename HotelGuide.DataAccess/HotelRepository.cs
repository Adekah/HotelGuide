using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using HotelGuide.Entity.Model;

namespace HotelGuide.DataAccess
{
    public class HotelRepository : IRepository<HotelsViewModel>
    {


        public List<HotelsViewModel> GetAll()
        {
            var context = new HotelDBContext();

            var _hotels = (from h in context.Hotel
                           join hs in context.HotelScore on h.Id equals hs.HotelId
                           join hi in context.HotelImage on h.Id equals hi.HotelId
                           select new HotelsViewModel { Id = h.Id, Name = h.Name, Description = h.Description, ScoreValue = hs.ScoreValue, ImagePath = hi.ImagePath });

            List<HotelsViewModel> _hotellist = _hotels.ToList();
            return _hotellist;

        }



        public List<HotelsViewModel> GetSelectedHotels(string searchString)
        {
            var context = new HotelDBContext();

            var searchResult = (from h in context.Hotel
                                join hs in context.HotelScore on h.Id equals hs.HotelId
                                join hi in context.HotelImage on h.Id equals hi.HotelId
                                join ha in context.HotelAddress on h.Id equals ha.HotelId
                                select new HotelsViewModel { Id = h.Id, Name = h.Name, Description = h.Description, AddressText = ha.AddressText, ScoreValue = hs.ScoreValue, ImagePath = hi.ImagePath }).
                Where(x => x.Name.Contains(searchString) || x.AddressText.Contains((searchString)));

            List<HotelsViewModel> searchHotels = searchResult.ToList();

            return searchHotels;
        }

        public HotelsViewModel GetHotelDetail(int id)
        {
            var context = new HotelDBContext();

            var balance = (from h in context.Hotel
                           join ha in context.HotelAddress on h.Id equals ha.HotelId
                           join hs in context.HotelScore on h.Id equals hs.HotelId
                           join hi in context.HotelImage on h.Id equals hi.HotelId
                           where h.Id == id
                           select new HotelsViewModel { Id = h.Id, Name = h.Name, Description = h.Description, AddressText = ha.AddressText, ScoreValue = hs.ScoreValue, ImagePath = hi.ImagePath }).SingleOrDefault();

            return balance;
        }

        public List<HotelContact> GetHotelContact(int id)
        {
            var context = new HotelDBContext();

            var contacts = context.HotelContact.Where(x => x.HotelId == id).ToList();
            return contacts;

        }

        public List<HotelComment> GetHotelComment(int id)
        {
            var context = new HotelDBContext();

            var comments = context.HotelComment.Where(x => x.HotelId == id).ToList();
            return comments;

        }

        public HotelComment AddHotelComment(HotelComment hotelcomment)
        {
            var context = new HotelDBContext();
            try
            {
                if (hotelcomment.Id == 0)
                {
                    context.HotelComment.Add(hotelcomment);

                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return hotelcomment;
        }









        public HotelsViewModel Get(int id)
        {

            throw new NotImplementedException();
        }

        public void Insert(HotelsViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(HotelsViewModel entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
