using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWidget.Models
{
    public class Hotel
    {
        public string FileName { get; set; }
        public decimal GuestRating { get; set; }
        public int ID { get; set; }
        public string Image { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public int NumberOfReviews { get; set; }
        public Place Place { get; set; }
        public decimal Rate { get; set; }
        public int StarRating { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
