using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IceCreamClient.Controllers
{
    public class HomeController : Controller
    {
        const string BASE_URL = "http://localhost:47255";
        IHttpClientFactory factory;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            this.factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = factory.CreateClient();//tạo và nhận data
            //View Books index
            var resultBook = await client.GetStringAsync(BASE_URL + "/api/book");
            var books = JsonConvert.DeserializeObject<List<BookIceCream>>(resultBook);
            TempData["ListBook"] = books;
            client.Dispose();

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
