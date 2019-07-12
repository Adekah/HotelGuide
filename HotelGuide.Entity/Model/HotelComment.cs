using System;
using System.Collections.Generic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelComment
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public int? Score { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual User User { get; set; }
    }
}
