using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelRoomPrice
    {
        public int Id { get; set; }
        public int? HotelRoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual HotelRoom HotelRoom { get; set; }
    }
}
