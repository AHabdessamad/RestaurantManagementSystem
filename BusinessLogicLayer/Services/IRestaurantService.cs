using BusinessLogicLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IRestaurantService
    {
        public Task<List<RestaurantDto>> GetRestaurantsAsync();
        public Task<RestaurantDto> GetRestaurantByIdAsync(string id);
        public Task<RestaurantDto> AddRestaurantAsync(RestaurantDto restaurant);
        public Task<RestaurantDto> UpdateRestaurantAsync(RestaurantDto restaurant);
        public Task<bool> DeleteRestaurantAsync(string id);
        public Task<List<RestaurantDto>> GetRestaurantsByCuisine(string cuisine);
    }
}
