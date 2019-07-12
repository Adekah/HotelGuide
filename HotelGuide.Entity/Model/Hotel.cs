using System;
using System.Collections.Generic;
using HotelGuide.Entity.Model;

namespace HotelGuide.Entity.Model
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelAddress = new HashSet<HotelAddress>();
            HotelComment = new HashSet<HotelComment>();
            HotelContact = new HashSet<HotelContact>();
            HotelImage = new HashSet<HotelImage>();
            HotelRoom = new HashSet<HotelRoom>();
            HotelScore = new HashSet<HotelScore>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<HotelAddress> HotelAddress { get; set; }
        public virtual ICollection<HotelComment> HotelComment { get; set; }
        public virtual ICollection<HotelContact> HotelContact { get; set; }
        public virtual ICollection<HotelImage> HotelImage { get; set; }
        public virtual ICollection<HotelRoom> HotelRoom { get; set; }
        public virtual ICollection<HotelScore> HotelScore { get; set; }
    }
}
