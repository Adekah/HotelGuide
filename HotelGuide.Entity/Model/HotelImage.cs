using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelImage
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
