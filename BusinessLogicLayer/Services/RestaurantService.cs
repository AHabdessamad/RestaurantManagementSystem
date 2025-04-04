using AutoMapper;
using BusinessLogicLayer.Dtos;
using DataAccessLayer.Entities;
using RestaurantMangementSystem.Repositories;

namespace BusinessLogicLayer.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<RestaurantDto> AddRestaurantAsync(RestaurantDto restaurant)
        {
            var _restaurant = _mapper.Map<Restaurant>(restaurant);  
            return await _restaurantRepository.AddRestaurantAsync(_restaurant)
                    .ContinueWith(t => _mapper.Map<RestaurantDto>(t.Result)); 
        }

        public async Task<bool> DeleteRestaurantAsync(string id)
        {
            return await _restaurantRepository.DeleteRestaurantAsync(id);
        }

        public async Task<List<RestaurantDto>> GetRestaurantsByCuisine(string cuisine)
        {
            return await _restaurantRepository.GetRestaurantsByCuisine(cuisine)
                .ContinueWith(t => _mapper.Map<List<RestaurantDto>>(t.Result));
        }

        public async Task<RestaurantDto> GetRestaurantByIdAsync(string id)
        {
            return await _restaurantRepository.GetRestaurantByIdAsync(id)
                .ContinueWith(t => _mapper.Map<RestaurantDto>(t.Result));
        }

        public async Task<List<RestaurantDto>> GetRestaurantsAsync()
        {
            return await _restaurantRepository.GetRestaurantsAsync()
                .ContinueWith(t => _mapper.Map<List<RestaurantDto>>(t.Result));
        }

        public async Task<RestaurantDto> UpdateRestaurantAsync(RestaurantDto restaurant)
        {
            return await _restaurantRepository.UpdateRestaurantAsync(_mapper.Map<Restaurant>(restaurant))
                .ContinueWith(t => _mapper.Map<RestaurantDto>(t.Result));
        }

    }
}
