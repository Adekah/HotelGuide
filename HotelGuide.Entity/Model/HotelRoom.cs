using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            HotelRoomPrice = new HashSet<HotelRoomPrice>();
        }

        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public string RoomSummary { get; set; }
        public string RoomDetail { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<HotelRoomPrice> HotelRoomPrice { get; set; }
    }
}
