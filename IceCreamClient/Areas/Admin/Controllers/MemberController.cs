using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IceCreamClient.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        const string API_URl = "http://localhost:47255";
        IHttpClientFactory _factory;

        public MemberController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            HttpClient client = _factory.CreateClient();
            var result = await client.GetAsync(API_URl + $"/api/Member/All/");
            if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await result.Content.ReadAsStringAsync();
                var members = JsonConvert.DeserializeObject<List<Member>>(data);
                client.Dispose();
                return View(members);
            }
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            HttpClient client = _factory.CreateClient();
            var result = await client.GetAsync(API_URl + $"/api/Member/Detail/{id}");
            if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await result.Content.ReadAsStringAsync();
                var member = JsonConvert.DeserializeObject<Member>(data);
                client.Dispose();
                return View(member);
            }
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Deactive(string id)
        {
            HttpClient client = _factory.CreateClient();
            var result = await client.GetAsync(API_URl + $"/api/Member/Deactive/{id}");
            client.Dispose();
            if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Success"] = "Deactive Member Successfull";
            }
            else
            {
                TempData["Error"] = "Deactive Member Failed";
            }
            return RedirectToAction("Index");
        }
        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Active(string id)
        {
            HttpClient client = _factory.CreateClient();
            var result = await client.GetAsync(API_URl + $"/api/Member/Active/{id}");
            client.Dispose();
            if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Success"] = "Active Member Successfull";
            }
            else
            {
                TempData["Error"] = "Active Member Failed";
            }
            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string id)
        {
            HttpClient client = _factory.CreateClient();
            var result = await client.GetAsync(API_URl + $"/api/Member/ResetPassword/{id}");
            client.Dispose();
            if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Success"] = "Reset Member Password Successfull";
            }
            else
            {
                TempData["Error"] = "Reset Member Password  Failed";
            }
            return RedirectToAction("Index");
        }
    }
}
