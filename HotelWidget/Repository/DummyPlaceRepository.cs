using HotelWidget.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelWidget.Repository
{
    public class DummyPlaceRepository : IDummyPlaceRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Lazy<IDictionary<string, Place>> _places;


        public DummyPlaceRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _places = new Lazy<IDictionary<string, Place>>(LoadData, LazyThreadSafetyMode.PublicationOnly);
        }

        public Place Get(string fileName)
        {
            Place place;

            if (!_places.Value.TryGetValue(fileName, out place))
                return null;

            // Clone the place and hotels so we can assign random rates for each request.
            var random = new Random();
            var clonedPlace = new Place
            {
                CountryCode = place.CountryCode,
                FileName = place.FileName,
                HasBoundary = place.HasBoundary,
                ID = place.ID,
                IsSearchable = place.IsSearchable,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                Name = place.Name,
                PlaceType = place.PlaceType,
                UpdatedBy = place.UpdatedBy,
                UpdatedDate = place.UpdatedDate
            };

            clonedPlace.Hotels =
                (from hotel in place.Hotels
                 select new Hotel
                 {
                     FileName = hotel.FileName,
                     GuestRating = hotel.GuestRating,
                     ID = hotel.ID,
                     Image = hotel.Image,
                     Latitude = hotel.Latitude,
                     Longitude = hotel.Longitude,
                     Name = hotel.Name,
                     NumberOfReviews = hotel.NumberOfReviews,
                     Rate = Math.Round(10m + (decimal)random.NextDouble() * 1000m, 2),
                     StarRating = hotel.StarRating,
                     Place = clonedPlace,
                     UpdatedBy = hotel.UpdatedBy,
                     UpdatedDate = hotel.UpdatedDate
                 }).ToList();

            return clonedPlace;
        }

        private IDictionary<string, Place> LoadData()
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Repository\\data.json");
            var places = JsonConvert
                .DeserializeObject<IEnumerable<Place>>(File.ReadAllText(filePath))
                .ToDictionary(p => p.FileName, StringComparer.OrdinalIgnoreCase);

            foreach (var kvp in places)
            {
                foreach (var hotel in kvp.Value.Hotels)
                {
                    hotel.Place = kvp.Value;
                }
            }

            return places;
        }
    }
}
