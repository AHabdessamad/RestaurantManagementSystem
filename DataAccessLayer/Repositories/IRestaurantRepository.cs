using DataAccessLayer.Entities;

namespace RestaurantMangementSystem.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(string id);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(string id);
        Task<List<Restaurant>> GetRestaurantsByCuisine(string cuisine);
    }
}
