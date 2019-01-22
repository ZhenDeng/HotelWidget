using HotelWidget.Models;

namespace HotelWidget.Repository
{
    public interface IDummyPlaceRepository
    {
        Place Get(string fileName);
    }
}