using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using RestaurantMangementSystem.Data;
using RestaurantMangementSystem.Repositories;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Dtos;

namespace RestaurantMangementSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestaurantService _restaurantService;


        public RestaurantController(ApplicationDbContext context, IRestaurantService restaurantService)
        {
            _context = context;
            _restaurantService = restaurantService;
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Adresse,Cuisine,Note")] RestaurantDto restaurant)
        {
            if (ModelState.IsValid)
            {
                await _restaurantService.AddRestaurantAsync(restaurant);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Adresse,Cuisine,Note")] RestaurantDto restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _restaurantService.UpdateRestaurantAsync(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_restaurantService.GetRestaurantByIdAsync(restaurant.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
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
