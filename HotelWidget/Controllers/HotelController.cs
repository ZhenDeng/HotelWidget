using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWidget.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelWidget.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly IDummyPlaceRepository placeRepository;
        private readonly ILogger<HotelController> illoger;

        public HotelController(IDummyPlaceRepository placeRepository, ILogger<HotelController> illoger)
        {
            this.placeRepository = placeRepository;
            this.illoger = illoger;
        }

        [HttpGet("GetTokyoHotel")]
        public IActionResult GetTokyoHotel(string fileName)
        {
            try
            {
                return Ok(this.placeRepository.Get(fileName).Hotels.OrderBy(o => o.Rate).Take(5).ToList());
            }
            catch (Exception ex)
            {
                this.illoger.LogError($"Fail to get hotels: {ex}");
                return BadRequest();
            }
        }

        [HttpGet("GetNewYorkHotel")]
        public IActionResult GetNewYorkHotel(string fileName)
        {
            try
            {
                return Ok(this.placeRepository.Get(fileName).Hotels.OrderBy(o => o.Rate).Take(5).ToList());
            }
            catch (Exception ex)
            {
                this.illoger.LogError($"Fail to get hotels: {ex}");
                return BadRequest();
            }
        }
    }
}
