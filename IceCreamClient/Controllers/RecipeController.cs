using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

            _client.Dispose();
            return View(result);
            //}
            //return RedirectToAction("ErrorPage");
        }

        public async Task<IActionResult> Details(int RecipeId)
        {
            var responseDetails = await _client.GetAsync($"/api/recipe/{RecipeId}");
            var detailsData = await responseDetails.Content.ReadAsStringAsync();
            var details = JsonConvert.DeserializeObject<Recipe>(detailsData);

            var responseLatest = await _client.GetAsync("/api/recipe/latest/3");
            var latestData = await responseLatest.Content.ReadAsStringAsync();
            var latest = JsonConvert.DeserializeObject<List<Recipe>>(latestData);

            var responseComment = await _client.GetAsync($"/api/comment/byRecipe/{RecipeId}");
            if (responseComment.IsSuccessStatusCode)
            {
                var commentData = await responseComment.Content.ReadAsStringAsync();
                var comment = JsonConvert.DeserializeObject<List<Comment>>(commentData);
                ViewData["Comment"] = comment;
            }

            _client.Dispose();

            ViewData["Details"] = details;
            ViewData["Latest"] = latest;          

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Comment(Comment comment)
        {

            comment.isReplied = false;

            var json = JsonConvert.SerializeObject(comment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/comment", content);

            _client.Dispose();
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Comment success";
                return RedirectToAction("Details", new { RecipeId = comment.RecipeId });
            }

            TempData["Error"] = "Comment error !";
            return RedirectToAction("Details", new { RecipeId = comment.RecipeId });
        }
    }
}
