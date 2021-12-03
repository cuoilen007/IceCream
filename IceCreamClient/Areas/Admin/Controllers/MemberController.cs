using Microsoft.AspNetCore.Mvc;

namespace IceCreamClient.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
