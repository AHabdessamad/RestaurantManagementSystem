
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RestaurantMangementSystem.Data;

namespace RestaurantMangementSystem.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;
        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<bool> DeleteRestaurantAsync(string id)
        {
            var restaurantToDelete = await GetRestaurantByIdAsync(id);
            if (restaurantToDelete == null)
            {
                return false;
            }
            _context.Restaurants.Remove(restaurantToDelete);
            _context.SaveChanges();
            return true;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(string id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return _context.Restaurants.ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantsByCuisine(string cuisine)
        {
            return await _context.Restaurants.Where(r => r.Cuisine == cuisine).ToListAsync();
        }

        public async Task<Restaurant> UpdateRestaurantAsync(Restaurant restaurant)
        {
            var existingRestaurant = await GetRestaurantByIdAsync(restaurant.Id);
            if(existingRestaurant == null)
            {
                return null;
            }
            existingRestaurant.Nom = restaurant.Nom;
            existingRestaurant.Adresse = restaurant.Adresse;
            existingRestaurant.Cuisine = restaurant.Cuisine;
            existingRestaurant.Note = restaurant.Note;
            _context.Restaurants.Update(existingRestaurant);
            _context.SaveChanges();
            return existingRestaurant;
        }
    }
}
