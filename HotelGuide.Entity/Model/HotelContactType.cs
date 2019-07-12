using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelContactType
    {
        public HotelContactType()
        {
            HotelContact = new HashSet<HotelContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HotelContact> HotelContact { get; set; }
    }
}
