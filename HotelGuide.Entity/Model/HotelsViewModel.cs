using System;
using System.Collections.Generic;
using System.Text;

namespace HotelGuide.Entity.Model
{
    public class HotelsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ScoreValue { get; set; }
        public string ImagePath { get; set; }
        public string AddressText { get; set; }
    }
}
