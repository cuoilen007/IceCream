using IceCreamClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamClient.Controllers
{
    public class MemberController : Controller
    {
        const string API_URl = "http://localhost:47255";
        IHttpClientFactory _factory;

        public MemberController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _factory.CreateClient();
                var result = await client.GetAsync(API_URl + $"/api/Member/Login/{Username}/{Password}");
                if(result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = await result.Content.ReadAsStringAsync();
                    var member = JsonConvert.DeserializeObject<Member>(data);
                    client.Dispose();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Member member)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _factory.CreateClient();
                var memberJson = JsonConvert.SerializeObject(member);
                var stringContent = new StringContent(memberJson, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(API_URl + "/api/Member/Register", stringContent);
                client.Dispose();
                if (result.IsSuccessStatusCode && result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home");
                }                
            }
            return View();
        }
    }
}
