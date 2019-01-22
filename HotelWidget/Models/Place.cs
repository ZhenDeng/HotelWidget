using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWidget.Models
{
    public class Place
    {
        public string CountryCode { get; set; }
        public string FileName { get; set; }
        public bool HasBoundary { get; set; }
        public IReadOnlyCollection<Hotel> Hotels { get; set; }
        public int ID { get; set; }
        public bool IsSearchable { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public string PlaceType { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
