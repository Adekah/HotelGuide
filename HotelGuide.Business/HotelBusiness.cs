using System;
using System.Collections.Generic;
using System.Text;
using HotelGuide.DataAccess;
using HotelGuide.Entity.Model;


namespace HotelGuide.Business
{
    public class HotelBusiness
    {
        public HotelsViewModel Get(int id)
        {
            HotelRepository repository = new HotelRepository();
            return repository.Get(id);
        }

        public List<HotelsViewModel> GetHotels()
        {
            HotelRepository repository = new HotelRepository();
            return repository.GetAll();
        }

        public List<HotelsViewModel> GetHotelSearchResult(string searchString)
        {
            HotelRepository repository = new HotelRepository();
            return repository.GetSelectedHotels(searchString);
        }



        //HotelDetails//

        public HotelsViewModel GetHotelDetail(int id)
        {
            HotelRepository repository = new HotelRepository();
            return repository.GetHotelDetail(id);
        }

        public List<HotelContact> GetHotelContact(int id)
        {
            HotelRepository repository = new HotelRepository();
            return repository.GetHotelContact(id);
        }
        public List<HotelComment> GetHotelComment(int id)
        {
            HotelRepository repository = new HotelRepository();
            return repository.GetHotelComment(id);
        }
    }
}
