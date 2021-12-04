using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamClient.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var response = await _client.GetAsync("/api/recipe");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Recipe>>(data);
                return View(result);
            }
            return RedirectToAction("ErrorPage");
        }

        public async Task<IActionResult> Details(int RecipeId)
        {
            var response = await _client.GetAsync($"/api/recipe/{RecipeId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Recipe>(data);
                return View(result);
            }
            return RedirectToAction("ErrorPage");
        }

        public async Task<IActionResult> Edit(int RecipeId)
        {
            var response = await _client.GetAsync($"/api/recipe/{RecipeId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Recipe>(data);
                return View(result);
            }
            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public async Task<IActionResult> Update(int RecipeId, Recipe recipe)
        {
            var json = JsonConvert.SerializeObject(recipe);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/api/recipe/{RecipeId}", content);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Success"] = "Update success";
                return RedirectToAction("Index");
            }
            ViewData["Error"] = "Input error !";
            return View();
        }

        public async Task<IActionResult> UpdateStatus(int RecipeId, bool status)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/api/recipe/{RecipeId}/{status}", content);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Success"] = "Update success";
                return View();
            }
            ViewData["Error"] = "Input error !";
            return View();
        }

        public async Task<IActionResult> UpdatePayingStatus(int RecipeId, bool payingStatus)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/api/recipe/payingRequired/{RecipeId}/{payingStatus}", content);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Success"] = "Update success";
                return View();
            }
            ViewData["Error"] = "Input error !";
            return View();
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
