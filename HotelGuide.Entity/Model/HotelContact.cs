using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelContact
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string ContactValue { get; set; }
        public int HotelContactTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual HotelContactType HotelContactType { get; set; }
    }
}
