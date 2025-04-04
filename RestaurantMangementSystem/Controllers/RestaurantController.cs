
using RestaurantMangementSystem.Data;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Dtos;
using RestaurantMangementSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantMangementSystem.Controllers
{
    //[Route("[controller]/[action]")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;


        public RestaurantController(ApplicationDbContext context, IRestaurantService restaurantService, IMapper mapper)
        {
            _context = context;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantService.GetRestaurantsAsync();
            return View(restaurants);
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Adresse,Cuisine,Note")] RestaurantModel restaurant)
        {
            if (ModelState.IsValid)
            {
                var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
                await _restaurantService.AddRestaurantAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurant/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Adresse,Cuisine,Note")] RestaurantModel restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
                await _restaurantService.UpdateRestaurantAsync(restaurantDto);
            }

             return RedirectToAction("Index");
        }

        // GET: Restaurant/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Cuisine
        [HttpGet("{cuisine}")]
        public async Task<IActionResult> Cuisine(string cuisine)
        {
            if (cuisine == null)
            {
                return NotFound();
            }
            var restaurants = await _restaurantService.GetRestaurantsByCuisine(cuisine);

            return View("Index", restaurants);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
