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
    }
}
