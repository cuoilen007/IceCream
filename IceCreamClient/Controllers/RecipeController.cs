using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IceCreamClient.Controllers
{
    public class RecipeController : Controller
    {
        const String BASE_URL = "http://localhost:47255";
        HttpClient _client;

        public RecipeController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(BASE_URL);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/recipe/active");
            //if (response.IsSuccessStatusCode)
            //{
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Recipe>>(data);
                return View(result);
            //}
            //return RedirectToAction("ErrorPage");
        }

        public async Task<IActionResult> Details(int RecipeId)
        {
            var response = await _client.GetAsync($"/api/recipe/{RecipeId}");
            //if (response.IsSuccessStatusCode)
            //{
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Recipe>(data);
                return View(result);
            //}
            //return RedirectToAction("ErrorPage");
        }
    }
}
